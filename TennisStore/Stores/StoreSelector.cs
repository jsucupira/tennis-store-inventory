using System;
using System.Collections.Generic;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Domain.MasterData.StoreAggregate;

namespace TennisStore.Stores
{
    /// <summary>
    /// Class StoreSelector.
    /// </summary>
    public static class StoreSelector
    {
        /// <summary>
        /// Gets the specified store identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>Store.</returns>
        /// <exception cref="Core.Common.Exceptions.NotValidException"></exception>
        /// <exception cref="Core.Common.Exceptions.NotFoundException">Store</exception>
        public static Store Get(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                throw new NotValidException(storeId);

            Store store = ContextFactory.Create<IStoreContext>().Get(guid);
            if (store == null)
                throw new NotFoundException("Store", storeId);

            return store;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>List&lt;Store&gt;.</returns>
        public static List<Store> FindAll()
        {
            return ContextFactory.Create<IStoreContext>().FindAll();
        }
    }
}
