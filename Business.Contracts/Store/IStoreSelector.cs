using System.Collections.Generic;
using Core.Common.Exceptions;

namespace Business.Contracts.Store
{
    public interface IStoreSelector
    {
        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Store&gt;.</returns>
        List<Domain.MasterData.StoreAggregate.Store> FindAll();

        /// <summary>
        ///     Gets the specified store identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>Store.</returns>
        /// <exception cref="Core.Common.Exceptions.NotValidException"></exception>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Store</exception>
        /// <exception cref="Core.Common.Exceptions.ResourceNotFoundException"></exception>
        Domain.MasterData.StoreAggregate.Store Get(string storeId);
    }
}