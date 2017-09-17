namespace Crip.Samples.Services.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Product Service Tests
    /// </summary>
    [TestClass]
    public partial class ProductServiceTests
    {
        private ProductService svc;

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            this.svc = new ProductService();
            this.svc.Context = TestSubstitutes.MockContext();
        }

        /// <summary>
        /// Tests product, all should return collection of products.
        /// </summary>
        [TestMethod]
        public async Task Test_Product_AllShouldReturnCollectionOfProducts()
        {
            var result = await this.svc.AllAsync();

            Assert.IsNotNull(
                result,
                "Method 'AllAsync' returned null instead of collection");

            Assert.IsTrue(
                result.Count() > 0,
                "Result count should be greater than a 0");
        }

        /// <summary>
        /// Tests product, find shouldreturnrecord with correct identifier.
        /// </summary>
        [TestMethod]
        public async Task Test_Product_FindShouldreturnrecordWithCorrectId()
        {
            var result = await this.svc.FindAsync(2);

            Assert.IsNotNull(
                result, "Method 'Find' returned null instead of record");

            Assert.AreEqual(
                2, result.Id, "Method 'Find' returned incorrect record");
        }
    }
}
