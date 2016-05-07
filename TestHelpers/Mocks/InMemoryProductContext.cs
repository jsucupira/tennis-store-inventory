using System.Collections.Generic;
using System.ComponentModel.Composition;
using Data.Contracts.Product;
using Domain.MasterData.ProductAggregate;

namespace TestHelpers.Mocks
{
    [Export(typeof (IProductRepository))]
    [Export(typeof (IProductReadOnlyRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InMemoryProductContext : IProductRepository, IProductReadOnlyRepository
    {
        private readonly InMemoryStorage<Product, string> _inMemoryStorage = new InMemoryStorage<Product, string>();

        public Product Get(string id)
        {
            return _inMemoryStorage.Get(id);
        }

        public List<Product> FindAll()
        {
            return _inMemoryStorage.FindAll();
        }

        public Product Create(Product entity)
        {
            return _inMemoryStorage.Create(entity);
        }

        public void Update(Product entity)
        {
            _inMemoryStorage.Update(entity);
        }

        public void Delete(string id)
        {
            _inMemoryStorage.Delete(id);
        }
    }
}