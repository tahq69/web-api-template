namespace Crip.Samples.Services
{
    using Crip.Samples.Models;
    using Crip.Samples.Models.Notification;
    using Crip.Samples.Models.User;
    using System.Threading.Tasks;

    /// <summary>
    /// Notification service contract.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation of
        /// message send.
        /// </returns>
        Task Send(Message message);

        /// <summary>
        /// Get inbox messages of the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="paged">The pagination.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation of
        /// received messages.
        /// </returns>
        Task<IPagedData<Message>> Inbox(User user, IPaged paged);

        /// <summary>
        /// Get outbox of the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="paged">The pagination.</param>
        /// <returns>
        /// A <see cref="Task" /> representing the asynchronous operation of
        /// sent messages.
        /// </returns>
        Task<IPagedData<Message>> Outbox(User user, IPaged paged);
    }
}
