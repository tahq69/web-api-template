namespace Crip.Samples.Models
{
    /// <summary>
    /// Product comment class
    /// </summary>
    public class ProductComment : IModel
    {
        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the comment author name.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the message of comment.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
