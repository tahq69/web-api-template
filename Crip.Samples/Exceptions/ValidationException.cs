namespace Crip.Samples.Exceptions
{
    using FluentValidation.Results;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Validation exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ValidationException : Exception
    {
        /// <summary>
        /// The errors from FluentValidator.
        /// </summary>
        private IList<ValidationFailure> errors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/>
        /// class.
        /// </summary>
        public ValidationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/>
        /// class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/>
        /// class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <param name="message">The message that describes the error.</param>
        public ValidationException(
            IList<ValidationFailure> errors,
            string message = "Validation error occured")
            : base(message)
        {
            this.errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/>
        /// class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null
        /// reference (Nothing in Visual Basic) if no inner exception is
        /// specified.
        /// </param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        public IList<KeyValuePair<string, string>> Errors
            => this.errors?.Select(error => new KeyValuePair<string, string>(
                error.PropertyName,
                error.ErrorMessage))?.ToList();

        /// <summary>
        /// To the JSON string.
        /// </summary>
        /// <returns>JSON serialized errors.</returns>
        internal string ToJsonString()
        {
            IEnumerable<(string key, IEnumerable<string> values)> grouped =
                this.Errors.GroupBy(error => error.Key)
                    .Select(group => (group.First().Key, group.Select(e => e.Value)));

            return $"{{{string.Join(",", grouped.Select(g => $"\"{g.key}\": [\"{string.Join("\",\"", g.values.Select(v => v.Replace("\"", "\\\"")))}\"]"))}}}";
        }
    }
}
