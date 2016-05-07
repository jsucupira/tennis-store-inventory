using System;

namespace Data.Contracts.Store
{
    public interface IStoreReadOnlyRepository : IReadOnlyRepository<Domain.MasterData.StoreAggregate.Store, Guid>
    {
    }
}