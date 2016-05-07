using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Store;
using Core.Common.Security;
using Data.Contracts.Store;
using Domain.MasterData.ProductAggregate;
using Domain.MasterData.StoreAggregate;

namespace Business.MasterData.Stores
{
    /// <summary>
    ///     Class StoreSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    [Export(typeof(IStoreSelector))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class StoreSelector : SelectorBase<Store, Guid>, IStoreSelector
    {

        [ImportingConstructor]
        public StoreSelector(IStoreReadOnlyRepository storeRepository): base(storeRepository)
        {
        }

        Store IStoreSelector.Get(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                CreateErrors.NotValid(storeId, nameof(storeId));

            return Get(guid);
        }

        List<Store> IStoreSelector.FindAll(bool active)
        {
            return FindAll(active);
        }
    }
}