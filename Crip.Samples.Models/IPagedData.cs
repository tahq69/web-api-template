namespace Crip.Samples.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Paginated data contract.
    /// </summary>
    /// <typeparam name="T">Paged data type.</typeparam>
    public interface IPagedData<T>
    {
        /// <summary>
        /// Gets or sets the total count of available data records.
        /// </summary>
        int Total { get; set; }

        /// <summary>
        /// Gets or sets the per page data count.
        /// </summary>
        int PerPage { get; set; }

        /// <summary>
        /// Gets or sets current page.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Gets or sets number of first record in current set.
        /// </summary>
        int From { get; set; }

        /// <summary>
        /// Gets or sets number of last record in current set.
        /// </summary>
        int To { get; set; }

        /// <summary>
        /// Gets or sets paginated data.
        /// </summary>
        IEnumerable<T> Data { get; set; }
    }
}
