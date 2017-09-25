namespace Crip.Samples.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Pagination model contract.
    /// </summary>
    public interface IPaged
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        int PageSize { get; set; }
    }
}
