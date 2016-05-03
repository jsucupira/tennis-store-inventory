using Core.Common.Exceptions;
using Core.Common.Model;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisStore.Products;

namespace TennisStoreTests.Products
{
    [TestClass]
    public class ProductSelectorTests : TestBase
    {
        [TestMethod]
        public void FindAllTest()
        {
            Assert.IsTrue(MefBase.Resolve<IProductContext>().FindAll().Count == 15);
        }

        [TestMethod]
        [ExpectedException(typeof (NotValidException))]
        public void GetBadIdTest()
        {
            MefBase.Resolve<IProductContext>().Get("");
        }

        [TestMethod]
        [ExpectedException(typeof (ResourceNotFoundException))]
        public void GetNonExistentTest()
        {
            MefBase.Resolve<IProductContext>().Get("adwda");
        }

        [TestMethod]
        public void GetTest()
        {
            Product product = MefBase.Resolve<IProductContext>().Get("1");
            Assert.IsTrue(product.Name == "Babolat Pure Control Tour");
            Assert.IsTrue(product.StandardCost == 159.00M);
            Assert.IsTrue(product.ProductCategoryId == 1);
        }
    }
}