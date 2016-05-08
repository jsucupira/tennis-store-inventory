using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts.Product;
using Core.Common.Exceptions;
using Core.Common.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisStoreTests.Products;

namespace TennisStoreTests.Base
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SelectorBaseTests : ProductTestBase
    {
        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void Get_Exceptions()
        {
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();
            productSelector.Get(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void Get_Exceptions2()
        {
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();
            productSelector.Get(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void Get_Exceptions3()
        {
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();
            productSelector.Get(Guid.Empty.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void Get_Exceptions4()
        {
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();
            productSelector.Get("0");
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void Get_Exceptions5()
        {
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();
            productSelector.Get("123");
        }
    }
}
