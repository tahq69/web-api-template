namespace Crip.Samples.Services
{
    using Crip.Samples.Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// User service contract.
    /// </summary>
    public interface IUserService : IService
    {
        /// <summary>
        /// Gets or sets the security service.
        /// </summary>
        ISecurityService SecurityService { get; set; }

        /// <summary>
        /// Authorizes user by the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Authorized user details.</returns>
        Task<UserDetails> Login(Credentials credentials);

        /// <summary>
        /// Registers user by the specified registration model.
        /// </summary>
        /// <param name="registration">The registration.</param>
        /// <returns>Authorized user details.</returns>
        Task<UserDetails> Register(Registration registration);

        /// <summary>
        /// Gets all users from database.
        /// </summary>
        /// <returns>Collection of all users.</returns>
        Task<IEnumerable<User>> All();

        /// <summary>
        /// Finds the user by the specified identifier.
        /// </summary>
        /// <param name="id">The user record identifier.</param>
        /// <returns>Single instance of a user.</returns>
        Task<User> Find(int id);
    }
}
