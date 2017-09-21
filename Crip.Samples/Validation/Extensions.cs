namespace Crip.Samples.Validation
{
    using Crip.Samples.Exceptions;

    /// <summary>
    /// Validation extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Validates the specified source model.
        /// </summary>
        /// <typeparam name="TModel">Type of entity to validate.</typeparam>
        /// <param name="src">Validation target object.</param>
        /// <param name="validator">The validator instance.</param>
        /// <exception cref="ValidationException">
        /// Thrown when <c>src</c> is not valid.
        /// </exception>
        public static void Validate<TModel>(
            this TModel src,
            BaseValidator<TModel> validator)
            where TModel : class
        {
            var result = validator.Validate(src);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
