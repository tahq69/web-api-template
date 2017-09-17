namespace Crip.Samples.Tests
{
    using Crip.Samples.Models;

    /// <summary>
    /// Product entity test data.
    /// </summary>
    public partial class TestData
    {
        /// <summary>
        /// Gets the product: tomato.
        /// </summary>
        public static Product ProductTomato => new Product
        {
            Id = 1,
            Name = "Tomato Soup",
            Category = "Groceries",
            Price = 1,
        };

        /// <summary>
        /// Gets the product: yo yo.
        /// </summary>
        public static Product ProductYoYo => new Product
        {
            Id = 2,
            Name = "Yo-yo",
            Category = "Toys",
            Price = 3.75M,
        };

        /// <summary>
        /// Gets the product: hammer.
        /// </summary>
        public static Product ProductHammer => new Product
        {
            Id = 3,
            Name = "Hammer",
            Category = "Hardware",
            Price = 16.99M,
        };

        /// <summary>
        /// Gets the collection of products.
        /// </summary>
        public static Product[] Products => new Product[]
        {
            TestData.ProductTomato,
            TestData.ProductYoYo,
            TestData.ProductHammer,
        };
    }
}
