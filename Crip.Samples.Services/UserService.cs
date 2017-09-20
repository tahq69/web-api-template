namespace Crip.Samples.Services
{
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
        /// Gets all users from database.
        /// </summary>
        /// <returns>
        /// Collection of all users.
        /// </returns>
        public async Task<IEnumerable<User>> All()
        {
            return await this.Context.Users.Select(user => new User
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Name = user.Name,
                Surname = user.Surname,
            }).ToListAsync();
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
    }
}
