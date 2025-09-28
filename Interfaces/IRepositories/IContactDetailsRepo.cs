namespace AuthApiBackend.Interfaces.IRepositories
{

    public interface IContactDetailsRepo
    {

        /// <summary>
        /// Add user contact entity to the database.
        /// </summary>
        /// <param name="contactDetails"> User contact details entity. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        Task CreateAsync(Models.ContactDetails contactDetails, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves user contact entity from the database.
        /// </summary>
        /// <param name="userId"> A Unique identifier that uniquely identify contact details to be read. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <returns> User Contact entity if found, otherwise, null. </returns>
        Task<Models.ContactDetails?> GetAsync(string userId, CancellationToken cancellationToken);

    }

}
