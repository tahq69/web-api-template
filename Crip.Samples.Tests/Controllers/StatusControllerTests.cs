namespace Crip.Samples.Tests.Controllers
{
    using Crip.Samples.Controllers;
    using Crip.Samples.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class StatusControllerTests
    {
        private StatusController ctrl;

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            var svc = new ProductService()
            {
                Context = TestSubstitutes.MockContext(),
            };

            this.ctrl = new StatusController
            {
                Products = svc,
            };
        }

        /// <summary>
        /// Tests API status controller: can get status details.
        /// </summary>
        [TestMethod]
        public async Task Test_ApiStatus_CanGetStatusDetails()
        {
            var status = await this.ctrl.GetStatus();

            Assert.IsNotNull(status, "Could not get API status details");

            Assert.AreEqual(
                "Crip_Samples_Name", status.Name,
                "Application name is not set");

            Assert.AreEqual(
                "Crip_Samples_Description", status.Description,
                "Application description is not set");

            Assert.AreEqual("OK", status.Database,
                "Application database instance is not set up correctly");
        }
    }
}
