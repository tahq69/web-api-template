namespace Crip.Samples.Tests
{
    using Crip.Samples.Data.Entities;
    using Crip.Samples.Tests.Utils;
    using NSubstitute;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class DbSetMock<T>
        where T : class, IEntity
    {
        private IDbSet<T> mock;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbSetMock{T}"/> class.
        /// Initialize database set with existing record-set
        /// </summary>
        /// <param name="dataCollection">Collection of fake data in DB.</param>
        public DbSetMock(IEnumerable<T> dataCollection)
        {
            var dataRef = dataCollection == null ?
                Enumerable.Empty<T>() :
                dataCollection;

            this.mock = Substitute.For<IDbSet<T>, IQueryable<T>, IDbAsyncEnumerable<T>>();

            this.Data = dataRef.AsQueryable();

            // Setup all IQueryable and IDbAsyncEnumerable methods using what
            // you have from "dataCollection"
            ((IDbAsyncEnumerable<T>)this.mock).GetAsyncEnumerator()
                .Returns(new TestDbAsyncEnumerator<T>(this.Data.GetEnumerator()));

            this.mock.Provider.Returns(new TestDbAsyncQueryProvider<T>(this.Data.Provider));
            this.mock.Expression.Returns(this.Data.Expression);
            this.mock.ElementType.Returns(this.Data.ElementType);
            this.mock.GetEnumerator().Returns(this.Data.GetEnumerator());

            this.mock.When(x => x.Add(Arg.Any<T>())).Do(x => this.Inserted.Add(x.Arg<T>()));
            this.mock.When(x => x.Remove(Arg.Any<T>())).Do(x => this.Deleted.Add(x.Arg<T>()));
        }

        /// <summary>
        /// Gets list of existing items.
        /// </summary>
        public IQueryable<T> Data { get; private set; }

        /// <summary>
        /// Gets or sets list of items treated as deleted.
        /// </summary>
        public List<T> Deleted { get; set; }

        /// <summary>
        /// Gets or sets list of items treated as inserted.
        /// </summary>
        public List<T> Inserted { get; set; }

        /// <summary>
        /// Gets database set mock object instance.
        /// </summary>
        public IDbSet<T> Mock => this.mock;

        /// <summary>
        /// Reset data in Deleted & Inserted objects.
        /// </summary>
        public void Reset()
        {
            this.Deleted = new List<T>();
            this.Inserted = new List<T>();
        }
    }
}
