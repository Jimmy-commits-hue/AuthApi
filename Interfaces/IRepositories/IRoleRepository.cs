using AuthApiBackend.Models;

namespace AuthApiBackend.Interfaces.IRepositories
{

    public interface IRoleRepository
    {

        /// <summary>
        /// Add a new role to the database.
        /// </summary>
        /// <param name="role"> Role entity to add. </param>
        /// <param name="cancellationToken"> Cancellation Token. </param>
        Task CreateAsync(Role role, CancellationToken cancellationToken);

        /// <summary>
        /// Update role entity in the database.
        /// </summary>
        /// <param name="role"> Role entity to be updated. </param>
        /// <param name="cancellationToken"> Cancellation token. </param>
        Task UpdateAsync(Role role, CancellationToken cancellationToken);

        /// <summary>
        /// Get all roles from the database.
        /// </summary>
        /// <param name="cancellationToken"> Cancellation token. </param>
        /// <returns> All roles entities if any, otherwise, null. </returns>
       Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get a specific role with related entities.
        /// </summary>
        /// <param name="role"> Role entity to be retrieved. </param>
        /// <param name="cancellationToken"> Cancellation Token. </param>
        /// <returns> Role Id (primary key) if found with its related data, otherwise, null. </returns>
        Task<int?> GetAsync(string role, CancellationToken cancellationToken);

        /// <summary>
        /// Remove Role entity from the database.
        /// </summary>
        /// <param name="role"> Role entity to be removed. </param>
        /// <param name="cancellationToken"> Cancellation Token. </param>
        Task DeleteAsync(Role role, CancellationToken cancellationToken);

    }

}
