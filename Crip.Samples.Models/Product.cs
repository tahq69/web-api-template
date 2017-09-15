namespace Crip.Samples.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Product class
    /// </summary>
    public class Product : IModel
    {
        /// <summary>
        /// Gets or sets the identifier of product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of product.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the price of product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the list of product comments.
        /// </summary>
        public virtual List<ProductComment> Comments { get; set; }
    }
}
