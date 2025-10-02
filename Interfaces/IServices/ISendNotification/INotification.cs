using AuthApiBackend.DTOs.TemplatesDto;

namespace AuthApiBackend.Interfaces.IServices.ISendNotification
{

    /// <summary>
    /// 
    /// </summary>
    public interface INotification
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendNotification(NotificationDto message);

    }

}
