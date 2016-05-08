using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Business.Contracts.Store;
using Core.Common.Exceptions;
using Core.Common.Model;
using Data.Contracts.Store;
using Domain.MasterData.StoreAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sampler;
using TestHelpers;

namespace TennisStoreTests.Stores
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class StoreSelectorTests : StoreBaseTest
    {
        [TestMethod]
        public void FindAll_NoValidEmailAndWeb()
        {
            Assert.IsTrue(StoreSelector.FindAll(true).Count == ACTIVE_STORES, $"Actual is {StoreSelector.FindAll(true).Count}");
            Assert.IsTrue(StoreSelector.FindAll(false).Count == NON_ACTIVE_STORES, $"Actual is {StoreSelector.FindAll(false).Count}");
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void GetTest_NotFoundException()
        {
            var store = StoreSelector.Get(Guid.NewGuid().ToString());
            Assert.IsNotNull(store);
            Assert.IsTrue(store.ManagerEmail.Equals("jsucu@test.com"));
            Assert.IsTrue(store.WebSiteUrl.Equals("http://www.test.com/"));
        }

        [TestMethod]
        public void GetTest()
        {
            var store = StoreSelector.Get(DefaultStoreId.ToString());
            Assert.IsNotNull(store);
            Assert.IsTrue(store.ManagerEmail.Equals("jsucu@test.com"));
            Assert.IsTrue(store.WebSiteUrl.Equals("http://www.test.com/"));
        }
    }
}