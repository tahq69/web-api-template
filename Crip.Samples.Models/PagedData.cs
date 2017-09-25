namespace Crip.Samples.Models
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Paginated data model.
    /// </summary>
    /// <typeparam name="T">Type of the paginated data.</typeparam>
    /// <seealso cref="Crip.Samples.Models.IPagedData{T}" />
    public class PagedData<T> : IPagedData<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedData{T}"/> class.
        /// </summary>
        public PagedData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedData{T}"/> class.
        /// </summary>
        /// <param name="paged">The pagination.</param>
        public PagedData(IPaged paged)
        {
            this.Page = paged.Page;
            this.PerPage = paged.PerPage;
            this.From = (paged.Page * paged.PerPage) - paged.PerPage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedData{T}"/> class.
        /// </summary>
        /// <param name="paged">The pagination.</param>
        /// <param name="data">The pagination data.</param>
        public PagedData(IPaged paged, IEnumerable<T> data)
            : this(paged)
        {
            this.Data = data;

            this.To = this.From + data.Count();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedData{T}"/> class.
        /// </summary>
        /// <param name="paged">The pagination.</param>
        /// <param name="data">The pagination data.</param>
        /// <param name="total">The total count of available data.</param>
        public PagedData(IPaged paged, IEnumerable<T> data, int total)
            : this(paged, data)
        {
            this.Total = total;
        }

        /// <summary>
        /// Gets or sets the total count of available data records.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the per page data count.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets current page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets number of first record in current set.
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Gets or sets number of last record in current set.
        /// </summary>
        public int To { get; set; }

        /// <summary>
        /// Gets or sets paginated data.
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }
}
