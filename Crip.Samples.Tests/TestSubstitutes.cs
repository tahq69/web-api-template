namespace Crip.Samples.Tests
{
    using Crip.Samples.Data;
    using Crip.Samples.Models;
    using Crip.Samples.Tests.Utils;
    using NSubstitute;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    /// <summary>
    /// Tests substitute helpers.
    /// </summary>
    public class TestSubstitutes
    {
        /// <summary>
        /// Mocks the database set.
        /// </summary>
        /// <typeparam name="T">Type of model.</typeparam>
        /// <param name="dataCollection">The data collection.</param>
        /// <returns>Mocked database set.</returns>
        public static IDbSet<T> MockDbSet<T>(IEnumerable<T> dataCollection)
            where T : class, IModel
        {
            var dataRef = dataCollection == null ?
                Enumerable.Empty<T>() :
                dataCollection;

            var mock = Substitute.For<IDbSet<T>, IQueryable<T>, IDbAsyncEnumerable<T>>();

            var data = dataRef.AsQueryable();

            // Setup all IQueryable and IDbAsyncEnumerable methods using what
            // you have from "dataCollection"
            ((IDbAsyncEnumerable<T>)mock).GetAsyncEnumerator()
                .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            mock.Provider.Returns(new TestDbAsyncQueryProvider<T>(data.Provider));
            mock.Expression.Returns(data.Expression);
            mock.ElementType.Returns(data.ElementType);
            mock.GetEnumerator().Returns(data.GetEnumerator());

            return mock;
        }

        /// <summary>
        /// Mocks the context.
        /// </summary>
        /// <returns>Mocked database context.</returns>
        public static IDatabaseContext MockContext()
        {
            var context = Substitute.For<IDatabaseContext>();
            var products = MockDbSet(TestData.Products);
            var productComments = MockDbSet<ProductComment>(null);

            context.Products.Returns(products);
            context.ProductComments.Returns(productComments);

            return context;
        }
    }
}
