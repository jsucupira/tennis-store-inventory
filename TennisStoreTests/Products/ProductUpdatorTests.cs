using Core.Common.Exceptions;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisStore.Products;

namespace TennisStoreTests.Products
{
    [TestClass]
    public class ProductUpdatorTests : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void DeleteWithoutId()
        {
            ProductUpdator.Delete(null);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.IsTrue(ProductSelector.FindAll().Count == 5);
            ProductUpdator.Delete("product_5");
            Assert.IsTrue(ProductSelector.FindAll().Count == 4);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException), "'Last Modified By' should not be empty.")]
        public void UpdateWithoutModifiedByTest()
        {
            Product product = ProductSelector.Get("product_1");
            product.Description = "Updated Description";
            ProductUpdator.Update(product);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Product product = ProductSelector.Get("product_4");
            Assert.IsTrue(product.Description == "This is the Fourth Product");
            Assert.IsTrue(product.Name == "Fourth Product");
            Assert.IsTrue(product.ProductCategoryId == 1);

            product.Description = "Updated Description";
            product.Name = "Updated Name";
            product.ProductCategoryId = 2;
            product.ModifiedBy("jsucupira");

            ProductUpdator.Update(product);
            product = ProductSelector.Get("product_4");

            Assert.IsTrue(product.Description == "Updated Description");
            Assert.IsTrue(product.Name == "Updated Name");
            Assert.IsTrue(product.ProductCategoryId == 2);
            Assert.IsTrue(product.LastModifiedBy == "jsucupira");
        }
    }
}