using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Core.Common.Exceptions;
using Domain.MasterData.StoreAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sampler;

namespace TennisStoreTests.Stores
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StoreUpdatorTests : StoreBaseTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void CreateTest_NotValidEmail()
        {
            SamplerOptions samplerOptions = new SamplerOptions();
            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyValue = "wrongemailaddress",
                PropertyName = nameof(Store.ManagerEmail)
            }, SamplerOptions.Options.DefaultValue);

            samplerOptions.PropertyOptions.Add(nameof(Store.WebSiteUrl), SamplerOptions.Options.NullValue);
            List<Store> stores = SamplerServices<Store>.CreateSampleData(1, samplerOptions);
            stores.ForEach(t => t.Activate());
            stores.ForEach(t => StoreUpdator.Create(t));
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void CreateTest_NotValidUrl()
        {
            SamplerOptions samplerOptions = new SamplerOptions();
            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyValue = "www.asdf",
                PropertyName = nameof(Store.WebSiteUrl)
            }, SamplerOptions.Options.DefaultValue);

            samplerOptions.PropertyOptions.Add(nameof(Store.ManagerEmail), SamplerOptions.Options.NullValue);
            List<Store> stores = SamplerServices<Store>.CreateSampleData(1, samplerOptions);
            stores.ForEach(t => t.Activate());
            stores.ForEach(t => StoreUpdator.Create(t));
        }

        [TestMethod]
        public void CreateTest()
        {
            SamplerOptions samplerOptions = new SamplerOptions();
            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyValue = "http://www.test.com/",
                PropertyName = nameof(Store.WebSiteUrl)
            }, SamplerOptions.Options.DefaultValue);

            samplerOptions.PropertyDefaults.Add(new PropertiesSettings
            {
                PropertyValue = "jsucu@test.com",
                PropertyName = nameof(Store.ManagerEmail)
            }, SamplerOptions.Options.DefaultValue);


            List<Store> stores = SamplerServices<Store>.CreateSampleData(1, samplerOptions);
            stores.ForEach(t => t.Activate());
            stores.ForEach(t => StoreUpdator.Create(t));
        }

        [TestMethod]
        public void DeleteTest()
        {
            StoreUpdator.Delete(DefaultStoreId);
        }

        [TestMethod]
        public void UpdateTest()
        {
            string name = "Clearwater, FL";
            var store = StoreSelector.Get(DefaultStoreId);
            Assert.IsFalse(store.Name.Equals(name));
            store.SetName(name);
            StoreUpdator.Update(store);
            store = StoreSelector.Get(DefaultStoreId);
            Assert.IsTrue(store.Name.Equals(name));
        }
    }
}