namespace Crip.Samples.Exceptions
{
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Validation exception.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
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
        /// When overridden in a derived class, sets the
        /// <see cref="T:System.Runtime.Serialization.SerializationInfo" />
        /// with information about the exception.
        /// </summary>
        /// <param name="info">
        /// The <see cref="T:System.Runtime.Serialization.SerializationInfo" />
        /// that holds the serialized object data about the exception being
        /// thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="T:System.Runtime.Serialization.StreamingContext" />
        /// that contains contextual information about the source or
        /// destination.
        /// </param>
        /// <exception cref="System.ArgumentNullException">info</exception>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        public override void GetObjectData(
            SerializationInfo info,
            StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            base.GetObjectData(info, context);

            info.AddValue("Errors", this.ToJsonString());
        }

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
