using System.Diagnostics.CodeAnalysis;
using Business.Contracts.Product;
using Core.Common.Exceptions;
using Core.Common.Model;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisStoreTests.Products
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ProductSelectorProductTests : ProductTestBase
    {
        [TestMethod]
        public void FindAllTest()
        {
            IProductSelector selector = MefBase.Resolve<IProductSelector>();
            Assert.IsTrue(selector.FindAll(true).Count == 15, $"Actual {selector.FindAll(true).Count}");
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void GetBadIdTest()
        {
            MefBase.Resolve<IProductSelector>().Get("");
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetNonExistentTest()
        {
            MefBase.Resolve<IProductSelector>().Get("adwda");
        }

        [TestMethod]
        public void GetTest()
        {
            Product product = MefBase.Resolve<IProductSelector>().Get("1");
            Assert.IsTrue(product.Name == "Babolat Pure Control Tour");
            Assert.IsTrue(product.StandardCost == 159.00M);
            Assert.IsTrue(product.ProductCategoryId == 1);
        }
    }
}