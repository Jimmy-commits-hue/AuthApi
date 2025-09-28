using AuthApiBackend.Models;

namespace AuthApiBackend.Interfaces.IRepositories
{

    public interface IUserRepository
    {

        /// <summary>
        /// Creates new user entity in the database.
        /// </summary>
        /// <param name="user"> New user entity to add. </param>
        /// <param name="cancellationToken"> The cancellation Token. </param>
        Task CreateAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves user entity from the database using their Hashed ID Number.
        /// </summary>
        /// <param name="idNumber"> User hashed ID Number. </param>
        /// <param name="cancellationToken"> The Cancellation Token. </param>
        /// <returns> The User Entity if found, otherwise, null. </returns>
        Task<User?> GetAsync(string idNumber, CancellationToken cancellationToken);

        /// <summary>
        /// Update user entity in the database.
        /// </summary>
        /// <param name="user"> User entity to be updated. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        Task UpdateAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Removes user entity from the database.
        /// </summary>
        /// <param name="user"> Entity of the user to be deleted. </param>
        /// <param name="cancellationToken"> The Cancellation Token. </param>
        Task DeleteAsync(User user, CancellationToken cancellationToken);

    }

}
