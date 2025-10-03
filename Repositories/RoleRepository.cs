using AuthApiBackend.Database;
using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApiBackend.Repositories
{

    /// <summary>
    /// Add, remove, modify, get roles.
    /// </summary>
    public class RoleRepository( AuthApiDbContext context) : IRoleRepository
    {

        /// <summary>
        /// Add a new role to the database.
        /// </summary>
        /// <param name="role"> Role entity to add. </param>
        /// <param name="cancellationToken"> Cancellation Token. </param>
        public async Task CreateAsync(Role role, CancellationToken cancellationToken)
        {

            context.Role.Add(role);
            await context.SaveChangesAsync(cancellationToken);

        }

        public async Task<int?> GetAsync(string role, CancellationToken cancellationToken)
        {

            return await context.Role
     .Where(u => u.RoleName == role)
     .Select(u => u.Id)
     .FirstOrDefaultAsync(cancellationToken);


        }

        public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Role role, CancellationToken cancellationToken)
        {

            context.Role.Update(role);
            await context.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteAsync(Role role, CancellationToken cancellationToken)
        {

            context.Role.Remove(role);
            await context.SaveChangesAsync(cancellationToken);

        }

    }
}
