namespace Crip.Samples.Services.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public partial class ProductServiceTests
    {
        private ProductService svc;

        [TestInitialize]
        public void SetUp()
        {
            this.svc = new ProductService();
        }

        [TestMethod]
        public void Test_Product_AllShouldReturnCollectionOfProducts()
        {
            var result = this.svc.All();

            Assert.IsNotNull(result, "Method 'All' returned null instead of collection");
            Assert.IsTrue(result.Count() > 0, "Result count should be greater than a 0");
        }

        [TestMethod]
        public void Test_Product_FindShouldreturnrecordWithCorrectIdentifier()
        {
            var result = this.svc.Find(2);

            Assert.IsNotNull(result, "Method 'Find' returned null instead of record");
            Assert.AreEqual(2, result.Id);
        }
    }
}
