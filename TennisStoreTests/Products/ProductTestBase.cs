using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Threading;
using Core.Common.Extensions;
using Core.Common.Model;
using Core.Common.Security;
using Data.Contracts.Product;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelpers;

namespace TennisStoreTests.Products
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ProductTestBase
    {
        [TestCleanup]
        public void Cleanup()
        {
            IProductRepository context = MefBase.Resolve<IProductRepository>();
            ProductTestData.Products.ForEach(t => context.Delete(t.Id));
        }

        [TestInitialize]
        public void Init()
        {
            GenericIdentity identity = new GenericIdentity("jsucupira");
            string[] roles = { SecurityGroups.ADMINISTRATOR };
            GenericPrincipal principal = new GenericPrincipal(identity, roles);
            Thread.CurrentPrincipal = principal;

            MefLoader.Initialize();
            IProductRepository repository = MefBase.Resolve<IProductRepository>();
            ProductTestData.Products.ForEach(t => t.Activate());
            ProductTestData.Products.ForEach(t => repository.Create(t));
        }
    }
}