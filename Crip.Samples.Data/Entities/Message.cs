namespace Crip.Samples.Data.Entities
{
    /// <summary>
    /// Message entity.
    /// </summary>
    public class Message : Entity, IEntity
    {
        /// <summary>
        /// Gets or sets address collection that contains the blind carbon copy
        /// (BCC) recipients for this message.
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the address collection that contains the carbon copy
        /// (CC) recipients for this message.
        /// </summary>
        public string CC { get; set; }

        /// <summary>
        /// Gets or sets from user identifier.
        /// </summary>
        public long FromId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this message body is in
        /// HTML.
        /// </summary>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// Gets or sets the subject line for this message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the address collection that contains the recipients of
        /// this message.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets from user.
        /// </summary>
        public virtual User From { get; set; }
    }
}
