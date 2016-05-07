using System;

namespace Data.Contracts.Store
{
    public interface IStoreRepository : IRepository<Domain.MasterData.StoreAggregate.Store, Guid>
    {
    }
}