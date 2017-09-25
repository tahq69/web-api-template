namespace Crip.Samples.Models
{
    /// <summary>
    /// pagination model base.
    /// </summary>
    public class Paged : IPaged
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        public int PageSize { get; set; }
    }
}
