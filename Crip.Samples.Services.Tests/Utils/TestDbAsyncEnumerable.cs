namespace Crip.Samples.Services.Tests.Utils
{
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    /// <summary>
    /// Database async enumerable test implemenetation.
    /// </summary>
    /// <typeparam name="T">Type of model.</typeparam>
    /// <seealso cref="System.Linq.EnumerableQuery{T}" />
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncEnumerable{T}" />
    /// <seealso cref="System.Linq.IQueryable{T}" />
    public class TestDbAsyncEnumerable<T> :
        EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbAsyncEnumerable{T}"/> class.
        /// </summary>
        /// <param name="enumerable">A collection to associate with the new instance.</param>
        public TestDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbAsyncEnumerable{T}"/> class.
        /// </summary>
        /// <param name="expression">An expression tree to associate with the new instance.</param>
        public TestDbAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        /// <summary>
        /// Gets an enumerator that can be used to asynchronously enumerate the
        /// sequence.
        /// </summary>
        /// <returns>
        /// Enumerator for asynchronous enumeration over the sequence.
        /// </returns>
        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
            => new TestDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

        /// <summary>
        /// Gets the asynchronous enumerator.
        /// </summary>
        /// <returns>
        /// Enumerator for asynchronous enumeration over the sequence.
        /// </returns>
        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
            => this.GetAsyncEnumerator();

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        IQueryProvider Provider
            => new TestDbAsyncQueryProvider<T>(this);
    }
}
