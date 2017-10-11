namespace Crip.Samples.Data
{
    using System;

    /// <summary>
    /// Database transaction contract.
    /// </summary>
    public interface IDatabaseTransaction : IDisposable
    {
        /// <summary>
        /// Commits the underlying store transaction.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back the underlying store transaction.
        /// </summary>
        void Rollback();
    }
}
