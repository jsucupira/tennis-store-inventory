using Core.Common.Exceptions;

namespace Business.Contracts.Store
{
    public interface IStoreUpdator
    {
        /// <summary>
        ///     Creates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns>Store.</returns>
        Domain.MasterData.StoreAggregate.Store Create(Domain.MasterData.StoreAggregate.Store store);

        /// <summary>
        ///     Deletes the specified store identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void Delete(string storeId);

        /// <summary>
        ///     Updates the specified store.
        /// </summary>
        /// <param name="store">The store.</param>
        void Update(Domain.MasterData.StoreAggregate.Store store);
    }
}