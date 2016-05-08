using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Contracts.Store;
using Core.Common.Extensions;
using Core.Common.Model;
using Core.Common.Security;
using Data.Contracts.Product;
using Data.Contracts.Store;
using Domain.MasterData.StoreAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sampler;
using TennisStoreTests.Products;
using TestHelpers;

namespace TennisStoreTests.Stores
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StoreBaseTest
    {
        protected const int ACTIVE_STORES = 21;
        protected const int NON_ACTIVE_STORES = 10;
        protected IStoreSelector StoreSelector;
        protected IStoreUpdator StoreUpdator;
        protected readonly string DefaultStoreId = Guid.NewGuid().ToString();

        [TestCleanup]
        public void Cleanup()
        {
            IStoreRepository context = MefBase.Resolve<IStoreRepository>();
            context.FindAll().ForEach(t => context.Delete(t.Id));
        }

        [TestInitialize]
        public void InitializeTest()
        {
            GenericIdentity identity = new GenericIdentity("jsucupira");
            string[] roles = { SecurityGroups.ADMINISTRATOR };
            GenericPrincipal principal = new GenericPrincipal(identity, roles);
            Thread.CurrentPrincipal = principal;

            MefLoader.Initialize();
            IStoreRepository repository = MefBase.Resolve<IStoreRepository>();
            StoreSelector = MefBase.Resolve<IStoreSelector>();
            StoreUpdator = MefBase.Resolve<IStoreUpdator>();

            SamplerOptions samplerOptions = new SamplerOptions();
            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyValue = "jsucu@test.com",
                PropertyName = nameof(Store.ManagerEmail)
            }, SamplerOptions.Options.DefaultValue);
            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyValue = "http://www.test.com/",
                PropertyName = nameof(Store.WebSiteUrl)
            }, SamplerOptions.Options.DefaultValue);

            samplerOptions.PropertyOptions.Add(nameof(Store.Description), SamplerOptions.Options.Paragraph);
            samplerOptions.PropertyOptions.Add(nameof(Store.Name), SamplerOptions.Options.OneWord);
            samplerOptions.PropertyOptions.Add(nameof(Store.ManagerName), SamplerOptions.Options.OneWord);
            List<Store> stores = SamplerServices<Store>.CreateSampleData(ACTIVE_STORES - 1, samplerOptions);
            stores.ForEach(t => t.Activate());
            //Creating active classes
            stores.ForEach(t => repository.Create(t));

            //Creating non active classes
            SamplerServices<Store>.CreateSampleData(NON_ACTIVE_STORES, samplerOptions).ForEach(t => repository.Create(t));

            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyName = nameof(Store.Id),
                PropertyValue = DefaultStoreId.ToString()
            }, SamplerOptions.Options.DefaultValue);
            List<Store> defaultStore = SamplerServices<Store>.CreateSampleData(1, samplerOptions);
            defaultStore.ForEach(t => t.Activate());
            defaultStore.ForEach(t => repository.Create(t));
        }
    }
}
