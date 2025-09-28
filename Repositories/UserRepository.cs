using AuthApiBackend.Database;
using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApiBackend.Repositories
{

    /// <summary>
    /// Add, Retrieves, Update and Delete user entity from the database.
    /// </summary>
    public class UserRepository(AuthApiDbContext context) : IUserRepository
    {

        /// <summary>
        /// Creates a new user entity.
        /// </summary>
        /// <param name="user"> User entity to add. </param>
        /// <param name="cancellationToken"> The Cancellation Token </param>
        public async Task CreateAsync(User user, CancellationToken cancellationToken)
        {

            context.User.Add(user);
            await context.SaveChangesAsync(cancellationToken);

        }

        /// <summary>
        /// Searches for a user by their hashed ID number.
        /// </summary>
        /// <param name="idNumber"> Hashed user ID number </param>
        /// <param name="cancellationToken"> The Cancellation Token </param>
        /// <returns> The user if found, otherwise, null</returns>
        public async Task<User?> GetAsync(string idNumber, CancellationToken cancellationToken)
        {

            return await context.User.FirstOrDefaultAsync(u => u.IdNumber.CompareTo(idNumber) == 0, cancellationToken);

        }

        /// <summary>
        /// Method to update the entity of the specified user
        /// </summary>
        /// <param name="user"> User entity to update. </param>
        /// <param name="cancellationToken"> The Cancellation token </param>
        public async Task UpdateAsync(User user, CancellationToken cancellationToken)
        {

            context.User.Update(user);
            await context.SaveChangesAsync(cancellationToken);

        }

        /// <summary>
        /// Method to remove the entity of the user 
        /// </summary>
        /// <param name="user"> User entity to delete. </param>
        /// <param name="cancellationToken"> The Cancellation token </param>
        public async Task DeleteAsync(User user, CancellationToken cancellationToken)
        {

            context.User.Remove(user);
            await context.SaveChangesAsync(cancellationToken);

        }

    }

}
