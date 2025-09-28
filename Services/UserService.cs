using AuthApiBackend.DTOs;
using AuthApiBackend.Exceptions.ExceptionTypes;
using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Interfaces.IServices;
using AuthApiBackend.Models;
using AuthApiBackend.Utilities;

namespace AuthApiBackend.Services
{

    /// <summary>
    /// Create, Retrieves user information.
    /// </summary>
    public class UserService(IUserRepository userRepo) : IUserService
    {

        /// <summary>
        /// Creates new user entity in the system.
        /// </summary>
        /// <param name="user"> New user registration data. </param>
        /// <param name="cancellationToken"> The Cancellation Token. </param>
        /// <returns> The generated Id (Primary Key) recently created User. </returns>
        /// <exception cref="UserAlreadyExistException"> 
        /// Thrown if a user with the same ID number already exists in the database.
        /// </exception>
        public async Task<string> CreateUserAsync(RegisterDto user, CancellationToken cancellationToken)
        {

            //Hashing user ID Number for consistent storage and comparison
            var IdNumber = HashHelper.HashId(user.IdNumber);

            //check if the user with the hashed ID Number already exist.
            var userExist = await userRepo.GetAsync(IdNumber, cancellationToken);

            if (userExist is not null)
                throw new UserAlreadyExistException("User already exist");

            //Creating a new User entity
            var newUser = new User
            {
                IdNumber = IdNumber,
                FirstName = user.FirstName,
                Surname = user.Surname,
            };

            // Persist the new user to the database
            await userRepo.CreateAsync(newUser, cancellationToken);

            //returns generated user ID (Primary Key)
            return newUser.Id;

        }

        /// <summary>
        /// Retrieves user by the respective ID Number.
        /// </summary>
        /// <param name="idNumber"> User Id Number to be used to retrieve associated user Entity. </param>
        /// <param name="cancellationToken"> The Cancellation Token. </param>
        /// <returns>The User Entity if found. </returns>
        /// <exception cref="UserNotFoundException"> Thrown if no user is found with the specified ID Number. </exception>
        public async Task<User> GetUserAsync(string idNumber, CancellationToken cancellationToken)
        {

            //Look up for the user by hashed ID Number, throws if not found
            var userInfo = await userRepo.GetAsync(HashHelper.HashId(idNumber), cancellationToken)
                           ?? throw new UserNotFoundException("User does not exist");

            return userInfo;

        }

    }
}
