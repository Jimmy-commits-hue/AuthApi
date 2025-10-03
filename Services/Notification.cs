using AuthApiBackend.Configurations;
using AuthApiBackend.Interfaces.IServices.ISendNotification;
//using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorLight;

namespace AuthApiBackend.Services
{
    public class Notification : INotification
    {

        private readonly RazorLightEngine _engine;
        private readonly EmailConfig emailConfig;

        public Notification(IOptions<EmailConfig> options)
        {
            _engine = new RazorLightEngineBuilder().UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "Templates")).
                      UseMemoryCachingProvider().Build();

            emailConfig = options.Value;
        }

        public async Task SendNotification(DTOs.TemplatesDto.NotificationDto notification)
        {
            string template = string.Empty;

            if (!string.IsNullOrWhiteSpace(notification.VerificationLink))
            {
                template = "VericationEmail.cshtml";
            }
            else if (!string.IsNullOrWhiteSpace(notification.AccountNumber))
            {
                template = "AccountNumber.cshtml";
            }

            var fetchTemplate = string.Empty;

            var retrieveTemplate = _engine.Handler.Cache.RetrieveTemplate(template);

            if (retrieveTemplate.Success)
            {
                fetchTemplate = await _engine.RenderTemplateAsync(retrieveTemplate.Template.TemplatePageFactory(), notification);
            }
            else
            {
                await _engine.CompileTemplateAsync(template);
                
                fetchTemplate = await _engine.RenderTemplateAsync(retrieveTemplate.Template.TemplatePageFactory(), notification);
            }

            await SendEmail(notification.ToEmail, notification.Subject, fetchTemplate);
                
        }

        public async Task SendEmail(string toEmail, string subject, string message)   
        {

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("AuthApi", Environment.GetEnvironmentVariable("FROM_EMAIL")));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject; 

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = message
            };

            email.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(emailConfig.Host, int.Parse(emailConfig.Port), MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(Environment.GetEnvironmentVariable("FROM_EMAIL"), Environment.GetEnvironmentVariable("EMAIL_PASSWORD"));
            await client.SendAsync(email);
            await client.DisconnectAsync(true);

        }

    }

}
