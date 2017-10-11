namespace Crip.Samples.Models.Notification
{
    using System.Collections.Generic;

    /// <summary>
    /// Message model.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets address collection that contains the blind carbon copy
        /// (BCC) recipients for this message.
        /// </summary>
        public List<User.User> Bcc { get; set; }

        /// <summary>
        /// Gets or sets the message body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the address collection that contains the carbon copy
        /// (CC) recipients for this message.
        /// </summary>
        public List<User.User> CC { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this message body is in
        /// HTML.
        /// </summary>
        public bool IsBodyHtml { get; set; } = true;

        /// <summary>
        /// Gets or sets the subject line for this message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the address collection that contains the recipients of
        /// this message.
        /// </summary>
        public List<User.User> To { get; set; }

        /// <summary>
        /// Gets or sets from user.
        /// </summary>
        public User.User From { get; set; }
    }
}
