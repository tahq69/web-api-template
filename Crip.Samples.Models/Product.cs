namespace Crip.Samples.Models
{
    /// <summary>
    /// Product class
    /// </summary>
    public class Product
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
    }
}
