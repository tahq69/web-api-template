namespace Crip.Samples.Services
{
    using Crip.Samples.Models;
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
        /// Gets or sets the token service.
        /// </summary>
        ITokenService TokenService { get; set; }

        /// <summary>
        /// Gets or sets the notification service.
        /// </summary>
        INotificationService NotificationService { get; set; }

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
        /// Sends password reset email.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation.
        /// </returns>
        Task SendResetPassword(string email);

        /// <summary>
        /// Updates the password from password reset.
        /// </summary>
        /// <param name="token">Password reset token.</param>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Updated user details.</returns>
        Task<UserDetails> UpdatePassword(string token, Credentials credentials);

        /// <summary>
        /// Confirms user email address.
        /// </summary>
        /// <param name="token">Email confirmation token.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation of
        /// email confirmation.
        /// </returns>
        Task<bool> ConfirmEmail(string token);

        /// <summary>
        /// Gets paginated users from database.
        /// </summary>
        /// <param name="paged">The pagination.</param>
        /// <returns>
        /// Collection of paged users.
        /// </returns>
        Task<IPagedData<User>> All(IPaged paged);

        /// <summary>
        /// Finds the user by the specified identifier.
        /// </summary>
        /// <param name="id">The user record identifier.</param>
        /// <returns>Single instance of a user.</returns>
        Task<User> Find(int id);
    }
}
