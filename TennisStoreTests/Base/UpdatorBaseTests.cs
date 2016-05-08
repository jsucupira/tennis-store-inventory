using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts.Product;
using Core.Common.Exceptions;
using Core.Common.Model;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TennisStoreTests.Products;

namespace TennisStoreTests.Base
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UpdatorBaseTests : ProductTestBase
    {

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestNullException()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            productUpdator.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestInvalidIdException()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            var product = JsonConvert.DeserializeObject<Product>("{Id: ''}");
            productUpdator.Create(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestInvalidIdException2()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            var product = JsonConvert.DeserializeObject<Product>("{Id: ' '}");
            productUpdator.Create(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestInvalidIdException3()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            var product = JsonConvert.DeserializeObject<Product>("{Id: '0'}");
            productUpdator.Create(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestInvalidIdException4()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            var product = JsonConvert.DeserializeObject<Product>("{Id: '" + Guid.Empty + "'}");
            productUpdator.Create(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceAlreadyExistsException))]
        public void TestAlreadyExists()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            var product = JsonConvert.DeserializeObject<Product>("{Id: '1'}");
            productUpdator.Create(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestDeleteException()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            productUpdator.Delete(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestDeleteException2()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            productUpdator.Delete("");
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestDeleteException3()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            productUpdator.Delete("0");
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void TestDeleteException4()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            productUpdator.Delete(Guid.Empty.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void ProductValidation_UpdateException()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            Product product = JsonConvert.DeserializeObject<Product>("{ProductCategoryId: 1, Name: \"Tennis Shoes\", Id: ''}");
            productUpdator.Update(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void ProductValidation_UpdateException2()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            productUpdator.Update(null);
        }
    }
}
