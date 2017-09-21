namespace Crip.Samples.Validation
{
    using Crip.Samples.Data;
    using FluentValidation;

    /// <summary>
    /// Base validation abstraction.
    /// </summary>
    /// <typeparam name="T">Type of entity to validate.</typeparam>
    /// <seealso cref="FluentValidation.AbstractValidator{T}" />
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidator{T}"/>
        /// class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public BaseValidator(IDatabaseContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Gets the database context.
        /// </summary>
        public IDatabaseContext Context { get; }
    }
}
