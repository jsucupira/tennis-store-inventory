using System;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Store;
using Core.Common.Exceptions;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Data.Contracts.Store;
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
    internal class StoreUpdator : IStoreUpdator
    {
        private readonly IStoreRepository _storeRepository;

        [ImportingConstructor]
        public StoreUpdator(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        /// <summary>
        ///     Creates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>Store.</returns>
        public Store Create(Store store)
        {
            if (_storeRepository.Get(store.Id) != null)
                CreateErrors.ItemAlreadyExists(store.Id);

            store.ModifiedBy(ServiceBase.GetUserName());
            store.Validate();
            store.Activate();
            return _storeRepository.Create(store);
        }

        /// <summary>
        ///     Deletes the specified store identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <exception cref="NotValidException"></exception>
        public void Delete(string storeId)
        {
            Guid guid;
            if (!Guid.TryParse(storeId, out guid))
                CreateErrors.NotValid(storeId, nameof(storeId));

            _storeRepository.Delete(guid);
        }

        /// <summary>
        ///     Updates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        public void Update(Store store)
        {
            store.ModifiedBy(ServiceBase.GetUserName());
            store.Validate();
            _storeRepository.Update(store);
        }
    }
}