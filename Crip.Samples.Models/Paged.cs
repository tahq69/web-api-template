namespace Crip.Samples.Models
{
    /// <summary>
    /// pagination model base.
    /// </summary>
    public class Paged : IPaged
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Paged"/> class.
        /// </summary>
        public Paged()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Paged"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="perPage">The per page.</param>
        public Paged(int page, int perPage)
        {
            this.Page = page;
            this.PerPage = perPage;
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets count of the record to skip.
        /// </summary>
        public int Skip => (this.Page - 1) * this.PerPage;
    }
}
