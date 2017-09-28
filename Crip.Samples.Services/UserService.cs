namespace Crip.Samples.Services
{
    using Crip.Samples.Models;
    using Crip.Samples.Models.User;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Product service EF implementation.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.Service" />
    /// <seealso cref="Crip.Samples.Services.IUserService" />
    public class UserService : Service, IUserService
    {
        /// <summary>
        /// Gets or sets the security service.
        /// </summary>
        public ISecurityService SecurityService { get; set; }

        /// <summary>
        /// Gets or sets the token service.
        /// </summary>
        public ITokenService TokenService { get; set; }

        /// <summary>
        /// Gets or sets the notification service.
        /// </summary>
        public INotificationService NotificationService { get; set; }

        /// <summary>
        /// Gets paged users from database.
        /// </summary>
        /// <param name="paged">The pagination.</param>
        /// <returns>
        /// Collection of all users.
        /// </returns>
        public async Task<IPagedData<User>> All(IPaged paged)
        {
            var total = await this.Context.Users.CountAsync();
            var data = this.Context.Users
                .Take(paged.PerPage)
                .OrderBy(user => user.Id)
                .Skip(paged.Skip)
                .Select(user => new User
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username,
                    Name = user.Name,
                    Surname = user.Surname,
                })
                .ToList();

            return new PagedData<User>(paged, data, total);
        }

        /// <summary>
        /// Confirms user email address.
        /// </summary>
        /// <param name="token">Email confirmation token.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation of
        /// email confirmation.
        /// </returns>
        public Task<bool> ConfirmEmail(string token)
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
        public async Task<User> Find(int id)
        {
            var record = this.Context.Users
                .Where(user => user.Id == id)
                .Select(user => new User
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username,
                    Name = user.Name,
                    Surname = user.Surname,
                })
                .FirstOrDefault();

            return await Task.FromResult(record);
        }

        /// <summary>
        /// Authorizes user by the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>
        /// Authorized user details.
        /// </returns>
        public async Task<UserDetails> Login(Credentials credentials)
        {
            var login = credentials.Username;
            var auth = this.Context.Users
                .Where(user => user.Email == login || user.Username == login)
                .FirstOrDefault();

            if (auth == null)
            {
                return null;
            }

            var isValidPassword = this.SecurityService
                .IsHashEquals(credentials.Password, auth.Password);

            if (!isValidPassword)
            {
                return null;
            }

            var (token, guid) = this.TokenService.New(auth.Username);

            auth.RememberToken = guid;

            await this.Context.SaveChangesAsync();

            return new UserDetails
            {
                Id = auth.Id,
                Email = auth.Email,
                Username = auth.Username,
                Name = auth.Name,
                Surname = auth.Surname,
                Token = token
            };
        }

        /// <summary>
        /// Registers user by the specified registration model.
        /// </summary>
        /// <param name="registration">The registration.</param>
        /// <returns>
        /// Authorized user details.
        /// </returns>
        public async Task<UserDetails> Register(Registration registration)
        {
            var passwordHash = this.SecurityService.Hash(registration.Password);

            var user = new Data.Entities.User
            {
                Email = registration.Email,
                Username = registration.Username,
                Name = registration.Name,
                Surname = registration.Surname,
                Password = passwordHash
            };

            this.Context.Users.Add(user);

            await this.Context.SaveChangesAsync();

            return new UserDetails
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
            };
        }

        /// <summary>
        /// Sends password reset email.
        /// </summary>
        /// <param name="email">User email.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation.
        /// </returns>
        public Task SendResetPassword(string email)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Updates the password from password reset.
        /// </summary>
        /// <param name="token">Password reset token.</param>
        /// <param name="credentials">The credentials.</param>
        /// <returns>
        /// Updated user details.
        /// </returns>
        public Task<UserDetails> UpdatePassword(string token, Credentials credentials)
        {
            throw new System.NotImplementedException();
        }
    }
}
