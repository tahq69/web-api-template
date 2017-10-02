namespace Crip.Samples.Services
{
    using System;
    using System.Threading.Tasks;
    using Crip.Samples.Models;
    using Crip.Samples.Models.Notification;
    using Crip.Samples.Models.User;

    /// <summary>
    /// Notification service.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.INotificationService" />
    public class NotificationService : INotificationService
    {
        /// <summary>
        /// Get inbox messages of the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="paged">The pagination.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation of
        /// received messages.
        /// </returns>
        public Task<IPagedData<Message>> Inbox(User user, IPaged paged)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get outbox of the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="paged">The pagination.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation of
        /// sent messages.
        /// </returns>
        public Task<IPagedData<Message>> Outbox(User user, IPaged paged)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation of
        /// message send.
        /// </returns>
        public Task Send(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
