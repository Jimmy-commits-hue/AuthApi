using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Interfaces.IServices;
using AuthApiBackend.Repositories;
using AuthApiBackend.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthApiBackend.RegisterServices
{
    public static class ServicesCollection
    {

        public static IServiceCollection AddServiceCollection(this IServiceCollection Services)
        {

            //Services
            Services.AddScoped<IContactDetailsService, ContactDetailsService>();
            Services.AddScoped<IUserService, UserService>();

            //Repositories
            Services.AddScoped<IContactDetailsRepo, ContactDetailsRepo>();
            Services.AddScoped<IUserRepository, UserRepository>();

            return Services;
            
        }

    }

}
