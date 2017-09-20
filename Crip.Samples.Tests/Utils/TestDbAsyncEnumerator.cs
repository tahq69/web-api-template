namespace Crip.Samples.Tests.Utils
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Database async enumerator test implemenetation.
    /// </summary>
    /// <typeparam name="T">Type of model.</typeparam>
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerator{T}" />
    public class TestDbAsyncEnumerator<T> : IDbAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> inner;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TestDbAsyncEnumerator{T}"/> class.
        /// </summary>
        /// <param name="enumerator">The enumerator.</param>
        public TestDbAsyncEnumerator(IEnumerator<T> enumerator)
        {
            this.inner = enumerator;
        }

        /// <summary>
        /// Moves the next asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// <c>true</c> if the enumerator was successfully advanced to the next
        /// element; <c>false</c> if the enumerator has passed the end of the
        /// collection.
        /// </returns>
        public Task<bool> MoveNextAsync(CancellationToken cancellationToken)
            => Task.FromResult(this.inner.MoveNext());

        /// <summary>
        /// Gets the current enumerator element.
        /// </summary>
        public T Current => this.inner.Current;

        /// <summary>
        /// Gets the current enumerator element.
        /// </summary>
        object IDbAsyncEnumerator.Current => this.Current;

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Do not dispose the inner enumerator, since it might be
                // enumerated again, reset it instead
                this.inner.Reset();
            }
        }
    }
}
