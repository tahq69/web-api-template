namespace Crip.Samples.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Crip.Samples.Data;

    /// <summary>
    /// Application service base implementation.
    /// </summary>
    public abstract class Service
    {
        /// <summary>
        /// Gets or sets database context instance.
        /// </summary>
        public IDatabaseContext Context { get; set; }
    }
}
