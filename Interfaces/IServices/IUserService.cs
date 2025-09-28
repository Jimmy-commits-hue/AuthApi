using AuthApiBackend.DTOs;
using AuthApiBackend.Models;

namespace AuthApiBackend.Interfaces.IServices
{
    public interface IUserService 
    {

        /// <summary>
        /// Create a new user entity.
        /// </summary>
        /// <param name="user"> User registration data. </param>
        /// <param name="cancellationToken"> The Cancellation Token. </param>
        /// <returns> ID (Primary Key) of the newly created user. </returns>
        Task<string> CreateUserAsync(RegisterDto user, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves user by their respective ID Number.
        /// </summary>
        /// <param name="idNumber"> User Id Number to search with. </param>
        /// <param name="cancellationToken"> Cancellation Token to gracefully cancel the operation if needed. </param>
        /// <returns> The user entity if found. </returns>
        Task<User> GetUserAsync(string idNumber, CancellationToken cancellationToken);

    }
}
