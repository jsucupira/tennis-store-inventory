using System;
using System.Collections.Generic;
using Core.Common.Service;

namespace Domain.MasterData.StoreAggregate
{
    public interface IStoreContext : IServices<Store, Guid>
    {
    }
}