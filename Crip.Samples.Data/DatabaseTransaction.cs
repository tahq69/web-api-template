namespace Crip.Samples.Data
{
    using System.Data.Entity;

    /// <summary>
    /// Database transaction.
    /// </summary>
    /// <seealso cref="Crip.Samples.Data.IDatabaseTransaction" />
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private DbContextTransaction contextTransaction;
        private bool isCommited = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseTransaction"/>
        /// class.
        /// </summary>
        /// <param name="contextTransaction">The context transaction.</param>
        public DatabaseTransaction(DbContextTransaction contextTransaction)
        {
            this.contextTransaction = contextTransaction;
        }

        /// <summary>
        /// Commits the underlying store transaction.
        /// </summary>
        public void Commit()
        {
            if (!this.isCommited)
            {
                this.contextTransaction.Commit();
                this.isCommited = true;
            }
        }

        /// <summary>
        /// Rolls back the underlying store transaction.
        /// </summary>
        public void Rollback()
        {
            this.contextTransaction.Rollback();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Commit();
            this.contextTransaction.Dispose();
        }
    }
}
