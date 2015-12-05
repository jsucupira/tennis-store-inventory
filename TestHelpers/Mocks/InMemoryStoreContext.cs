using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Domain.MasterData.ProductAggregate;
using Domain.MasterData.StoreAggregate;

namespace TestHelpers.Mocks
{
    [Export(typeof (IStoreContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InMemoryStoreContext : IStoreContext
    {
        private readonly InMemoryStorage<Store, Guid> _inMemoryStorage = new InMemoryStorage<Store, Guid>();

        public Store Get(Guid id)
        {
            return _inMemoryStorage.Get(id);
        }

        public List<Store> FindAll()
        {
            return _inMemoryStorage.FindAll();
        }

        public Store Create(Store entity)
        {
            return _inMemoryStorage.Create(entity);
        }

        public void Update(Store entity)
        {
            _inMemoryStorage.Update(entity);
        }

        public void Delete(Guid id)
        {
            _inMemoryStorage.Delete(id);
        }
    }
}