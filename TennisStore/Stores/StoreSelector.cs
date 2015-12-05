using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Security;
using Domain.MasterData.StoreAggregate;

namespace TennisStore.Stores
{
    /// <summary>
    ///     Class StoreSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    public static class StoreSelector
    {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>List&lt;Store&gt;.</returns>
        public static List<Store> FindAll()
        {
            return ContextFactory.Create<IStoreContext>().FindAll().Where(t => t.IsActive).ToList();
        }

        /// <summary>
        /// Gets the specified store identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>Store.</returns>
        /// <exception cref="Core.Common.Exceptions.NotValidException"></exception>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Store</exception>
        /// <exception cref="Core.Common.Exceptions.ResourceNotFoundException"></exception>
        public static Store Get(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                throw new NotValidException(storeId);

            Store store = ContextFactory.Create<IStoreContext>().Get(guid);
            if (store == null)
                CreateErrors.NotFound(storeId);

            return store;
        }
    }
}