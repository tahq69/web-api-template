namespace Crip.Samples.Services
{
    using Crip.Samples.Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Product service EF implementation.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.Service" />
    /// <seealso cref="Crip.Samples.Services.IUserService" />
    public class UserService : Service, IUserService
    {
        /// <summary>
        /// Gets all users from database.
        /// </summary>
        /// <returns>
        /// Collection of all users.
        /// </returns>
        public Task<IEnumerable<User>> All()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Finds the user by the specified identifier.
        /// </summary>
        /// <param name="id">The user record identifier.</param>
        /// <returns>
        /// Single instance of a user.
        /// </returns>
        public Task<User> Find(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Authorizes user by the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>
        /// Authorized user details.
        /// </returns>
        public Task<UserDetails> Login(Credentials credentials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Registers user by the specified registration model.
        /// </summary>
        /// <param name="registration">The registration.</param>
        /// <returns>
        /// Authorized user details.
        /// </returns>
        public Task<UserDetails> Register(Registration registration)
        {
            throw new System.NotImplementedException();
        }
    }
}
