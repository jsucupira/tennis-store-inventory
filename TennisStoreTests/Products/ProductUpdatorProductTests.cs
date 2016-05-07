using System.Diagnostics.CodeAnalysis;
using Business.Contracts.Product;
using Core.Common.Exceptions;
using Core.Common.Model;
using Domain.MasterData.ProductAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace TennisStoreTests.Products
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ProductUpdatorProductTests : ProductTestBase
    {
        [TestMethod]
        public void DeleteTest()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();

            Assert.IsTrue(productSelector.FindAll(true).Count == 15);
            productUpdator.Delete("5");
            Assert.IsTrue(productSelector.FindAll(true).Count == 14);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void DeleteWithoutId()
        {
            MefBase.Resolve<IProductUpdator>().Delete(null);
        }

        [TestMethod]
        public void UpdateTest()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            IProductSelector productSelector = MefBase.Resolve<IProductSelector>();
            Product product = productSelector.Get("4");
            Assert.IsTrue(product.Description == "With roots that extend all the way back to the Wilson Ultra and legendary Pro Staff 6.0 85, the Pro Staff 90 is a true classic. This one is built for advanced players in search of incredible feel, rock solid stability and surgical precision. Featuring the ultimate player's specs, the Pro Staff 90 includes a 12+ oz weight, headlight balance, thin beam, leather grip and Wilson's tried and true Graphite/Kevlar Layup. It also has Amplifeel Technology in the handle to filter out some of the harsher vibrations. All told these ingredients add up to an unmatched level of feel, precision and plow-through. From the baseline the control on full swings is simply amazing, as is the unmistakably sublime feel when contact is cleanly made. There's also some penetrating power available to those who can get the mass moving. At net the Pro Staff 90 provides remarkable stability and pinpoint accuracy, with enough weight to punch the ball deep. All in all, this venerable racquet is simply a great option for any serious player who wants to experience the ultimate in precision and stability along with that timeless Pro Staff feel.");
            Assert.IsTrue(product.Name == "Wilson Pro Staff 90");
            Assert.IsTrue(product.ProductCategoryId == 1);

            product.Description = "Updated Description";
            product.Name = "Updated Name";
            product.ProductCategoryId = 1;

            productUpdator.Update(product);
            product = productSelector.Get("4");

            Assert.IsTrue(product.Description == "Updated Description");
            Assert.IsTrue(product.Name == "Updated Name");
            Assert.IsTrue(product.LastModifiedBy == "jsucupira");
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void ProductValidation_Name()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            Product product = JsonConvert.DeserializeObject<Product>("{ProductCategoryId: 1, Id: \"1234\"}");
            productUpdator.Create(product);
        }

        [TestMethod]
        [ExpectedException(typeof(NotValidException))]
        public void ProductValidation_Category()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            Product product = JsonConvert.DeserializeObject<Product>("{Name: \"Tennis Shoes\", Id: \"1234\"}");
            productUpdator.Create(product);
        }

        [TestMethod]
        public void ProductValidation_Id()
        {
            IProductUpdator productUpdator = MefBase.Resolve<IProductUpdator>();
            Product product = JsonConvert.DeserializeObject<Product>("{ProductCategoryId: 1, Name: \"Tennis Shoes\"}");
            productUpdator.Create(product);
        }
    }
}