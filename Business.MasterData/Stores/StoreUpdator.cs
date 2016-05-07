using System;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Store;
using Business.MasterData.Vendors;
using Core.Common.Exceptions;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Data.Contracts;
using Data.Contracts.Store;
using Domain.MasterData.ProductAggregate;
using Domain.MasterData.StoreAggregate;

namespace Business.MasterData.Stores
{
    /// <summary>
    ///     Class StoreUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [Export(typeof(IStoreUpdator))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class StoreUpdator : UpdatorBase<Store, Guid>, IStoreUpdator
    {

        [ImportingConstructor]
        public StoreUpdator(IStoreRepository storeRepository, IArchiverRepository archiverRepository, IQueueRepository queueRepository): base(storeRepository, archiverRepository, queueRepository)
        {
        }

        /// <summary>
        ///     Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Store.</returns>
        Store IStoreUpdator.Create(Store entity)
        {
            return Create(entity);
        }

        /// <summary>
        ///     Deletes the specified entity identifier.
        /// </summary>
        /// <param name="storeId">The entity identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void IStoreUpdator.Delete(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                CreateErrors.NotValid(storeId, nameof(storeId));

            Delete(guid);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void IStoreUpdator.Update(Store entity)
        {
            Update(entity);
        }
    }
}