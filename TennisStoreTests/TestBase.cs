using System.Security.Principal;
using System.Threading;
using Core.Common.Extensions;
using Core.Common.Model;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisStore.Products;
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
            IProductContext context = MefBase.Resolve<IProductContext>();
            ProductTestData.Products.ForEach(t => context.Delete(t.Id));
        }

        [TestInitialize]
        public void Init()
        {
            MefLoader.Initialize();
            GenericIdentity identity = new GenericIdentity("jsucupira");
            string[] roles = {@"Administrators"};
            GenericPrincipal principal = new GenericPrincipal(identity, roles);
            Thread.CurrentPrincipal = principal;
            ProductTestData.Products.ForEach(t => MefBase.Resolve<IProductContext>().Create(t));
        }
    }
}