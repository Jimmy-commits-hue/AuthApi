using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Interfaces.IServices;
using AuthApiBackend.Repositories;
using AuthApiBackend.Services;

namespace AuthApiBackend.RegisterServices
{
    public static class ServicesCollection
    {

        public static IServiceCollection AddServiceCollection(this IServiceCollection Services)
        {

            //Services
            Services.AddScoped<IContactDetailsService, ContactDetailsService>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IRoleService, RoleService>();
            Services.AddScoped<IUserRoleService, UserRoleService>();

            //Repositories
            Services.AddScoped<IContactDetailsRepo, ContactDetailsRepo>();
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IRoleRepository, RoleRepository>();
            Services.AddScoped<IUserRoleRepository, UserRoleRepository>();  

            return Services;
            
        }

    }

}
