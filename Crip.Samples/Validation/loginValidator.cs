namespace Crip.Samples.Validation
{
    using Crip.Samples.Data;
    using Crip.Samples.Models.User;
    using FluentValidation;

    /// <summary>
    /// Login validation.
    /// </summary>
    public class LoginValidator : BaseValidator<Credentials>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginValidator"/>
        /// class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public LoginValidator(IDatabaseContext context)
            : base(context)
        {
            this.RuleFor(credentials => credentials.Password)
                .NotEmpty().WithMessage(Resources.Validation.NotEmpty);

            this.RuleFor(credentials => credentials.Username)
                .NotEmpty().WithMessage(Resources.Validation.NotEmpty);
        }
    }
}
