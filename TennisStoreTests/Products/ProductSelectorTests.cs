using Core.Common.Exceptions;
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
            Assert.IsTrue(ProductSelector.FindAll().Count == 5);
        }

        [TestMethod]
        [ExpectedException(typeof (NotValidException))]
        public void GetBadIdTest()
        {
            ProductSelector.Get("");
        }

        [TestMethod]
        [ExpectedException(typeof (NotFoundException))]
        public void GetNonExistentTest()
        {
            ProductSelector.Get("adwda");
        }

        [TestMethod]
        public void GetTest()
        {
            Product product = ProductSelector.Get("product_1");
            Assert.IsTrue(product.Description == "This is the first Product");
            Assert.IsTrue(product.Name == "First Product");
            Assert.IsTrue(product.ProductCategoryId == 1);
        }
    }
}