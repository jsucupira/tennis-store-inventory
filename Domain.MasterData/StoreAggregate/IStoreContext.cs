using System;
using System.Collections.Generic;
using Core.Common.Service;
using Data.Contracts;

namespace Domain.MasterData.StoreAggregate
{
    public interface IStoreContext : IServices<Store, Guid>
    {
    }
}