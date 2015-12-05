using System;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Helpers;
using Domain.MasterData.StoreAggregate;

namespace TennisStore.Stores
{
    public static class StoreUpdator
    {
        public static Store Create(Store store)
        {
            store.Validate();
            return ContextFactory.Create<IStoreContext>().Create(store);
        }

        public static void Delete(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                throw new NotValidException(storeId);

            ContextFactory.Create<IStoreContext>().Delete(guid);
        }

        public static void Update(Store store)
        {
            store.Validate();
            ContextFactory.Create<IStoreContext>().Update(store);
        }
    }
}