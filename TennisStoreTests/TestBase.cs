using Core.Common.Extensions;
using Core.Common.Factories;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisStoreTests.Products;
using TestHelpers;

namespace TennisStoreTests
{
    [TestClass]
    public class TestBase
    {
        [TestCleanup]
        public void Cleanup()
        {
            ProductTestData.Products.ForEach(t => ContextFactory.Create<IProductContext>().Delete(t.Id));
        }

        [TestInitialize]
        public void Init()
        {
            MefLoader.Initialize();
            ProductTestData.Products.ForEach(t => ContextFactory.Create<IProductContext>().Create(t));
        }
    }
}