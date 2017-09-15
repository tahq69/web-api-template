namespace Crip.Samples.Services.Tests.Utils
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Database async query provider test implemenetation.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="System.Data.Entity.Infrastructure.IDbAsyncQueryProvider" />
    public class TestDbAsyncQueryProvider<TEntity> : IDbAsyncQueryProvider
    {
        private readonly IQueryProvider inner;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="TestDbAsyncQueryProvider{TEntity}"/> class.
        /// </summary>
        /// <param name="provider">The query provider.</param>
        internal TestDbAsyncQueryProvider(IQueryProvider provider)
        {
            this.inner = provider;
        }

        /// <summary>
        /// Constructs an <see cref="T:System.Linq.IQueryable" /> object that
        /// can evaluate the query represented by a specified expression tree.
        /// </summary>
        /// <param name="expression">
        /// An expression tree that represents a LINQ query.
        /// </param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable" /> that can evaluate the
        /// query represented by the specified expression tree.
        /// </returns>
        public IQueryable CreateQuery(Expression expression) 
            => new TestDbAsyncEnumerable<TEntity>(expression);

        /// <summary>
        /// Constructs an <see cref="T:System.Linq.IQueryable`1" /> object that
        /// can evaluate the query represented by a specified expression tree.
        /// </summary>
        /// <typeparam name="TElement">
        /// The type of the elements of the
        /// <see cref="T:System.Linq.IQueryable`1" /> that is returned.
        /// </typeparam>
        /// <param name="expression">
        /// An expression tree that represents a LINQ query.
        /// </param>
        /// <returns>
        /// An <see cref="T:System.Linq.IQueryable`1" /> that can evaluate the
        /// query represented by the specified expression tree.
        /// </returns>
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestDbAsyncEnumerable<TElement>(expression);
        }

        /// <summary>
        /// Executes the query represented by a specified expression tree.
        /// </summary>
        /// <param name="expression">
        /// An expression tree that represents a LINQ query.
        /// </param>
        /// <returns>
        /// The value that results from executing the specified query.
        /// </returns>
        public object Execute(Expression expression)
            => this.inner.Execute(expression);

        /// <summary>
        /// Executes the strongly-typed query represented by a specified
        /// expression tree.
        /// </summary>
        /// <typeparam name="TResult">
        /// The type of the value that results from executing the query.
        /// </typeparam>
        /// <param name="expression">
        /// An expression tree that represents a LINQ query.
        /// </param>
        /// <returns>
        /// The value that results from executing the specified query.
        /// </returns>
        public TResult Execute<TResult>(Expression expression)
            => this.inner.Execute<TResult>(expression);

        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<object> ExecuteAsync(
            Expression expression, CancellationToken cancellationToken)
            => Task.FromResult(Execute(expression));

        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<TResult> ExecuteAsync<TResult>(
            Expression expression, CancellationToken cancellationToken)
            => Task.FromResult(Execute<TResult>(expression));
    }
}
