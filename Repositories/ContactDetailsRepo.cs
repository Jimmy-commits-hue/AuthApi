using AuthApiBackend.Database;
using AuthApiBackend.Interfaces.IRepositories;
using AuthApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApiBackend.Repositories
{
    /// <summary>
    /// Add, Retrieves contacts details.
    /// </summary>
    public class ContactDetailsRepo(AuthApiDbContext context) : IContactDetailsRepo
    {

        /// <summary>
        /// Add user contact details ( email in this instance) in the database
        /// </summary>
        /// <param name="contactDetails"> Contact details entity to add. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public async Task CreateAsync(ContactDetails contactDetails, CancellationToken cancellationToken)
        {

            context.ContactDetails.Add(contactDetails);
            await context.SaveChangesAsync(cancellationToken);

        }

        /// <summary>
        /// Get User contact info from the database
        /// </summary>
        /// <param name="userId"> The unique identifier of the user whose contact details are being retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        /// <returns> The user contact info if found, otherwise, null. </returns>
        public async Task<ContactDetails?> GetAsync(string userId, CancellationToken cancellationToken)
        {

            return await context.ContactDetails.FindAsync(userId, cancellationToken);

        }

    }

}
