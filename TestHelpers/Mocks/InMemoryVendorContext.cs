using System.Collections.Generic;
using System.ComponentModel.Composition;
using Domain.MasterData.ProductAggregate;
using Domain.MasterData.VendorAggregate;

namespace TestHelpers.Mocks
{
    [Export(typeof (IVendorContext))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class InMemoryVendorContext : IVendorContext
    {
        private readonly InMemoryStorage<Vendor, string> _inMemoryStorage = new InMemoryStorage<Vendor, string>();

        public Vendor Get(string id)
        {
            return _inMemoryStorage.Get(id);
        }

        public List<Vendor> FindAll()
        {
            return _inMemoryStorage.FindAll();
        }

        public Vendor Create(Vendor entity)
        {
            return _inMemoryStorage.Create(entity);
        }

        public void Update(Vendor entity)
        {
            _inMemoryStorage.Update(entity);
        }

        public void Delete(string id)
        {
            _inMemoryStorage.Delete(id);
        }
    }
}