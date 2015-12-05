using System;
using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Domain.MasterData.StoreAggregate;

namespace TennisStore.Stores
{
    /// <summary>
    /// Class StoreUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    public static class StoreUpdator
    {
        /// <summary>
        /// Creates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>Store.</returns>
        public static Store Create(Store store)
        {
            store.ModifiedBy(ServiceBase.GetUserName());
            store.Validate();
            return ContextFactory.Create<IStoreContext>().Create(store);
        }

        /// <summary>
        /// Deletes the specified store identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <exception cref="NotValidException"></exception>
        public static void Delete(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                throw new NotValidException(storeId);

            ContextFactory.Create<IStoreContext>().Delete(guid);
        }

        /// <summary>
        /// Updates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        public static void Update(Store store)
        {
            store.ModifiedBy(ServiceBase.GetUserName());
            store.Validate();
            ContextFactory.Create<IStoreContext>().Update(store);
        }
    }
}