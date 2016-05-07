using Core.Common.Exceptions;

namespace Business.Contracts.Store
{
    public interface IStoreUpdator
    {
        /// <summary>
        ///     Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Store.</returns>
        Domain.MasterData.StoreAggregate.Store Create(Domain.MasterData.StoreAggregate.Store entity);

        /// <summary>
        ///     Deletes the specified entity identifier.
        /// </summary>
        /// <param name="storeId">The entity identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void Delete(string storeId);

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(Domain.MasterData.StoreAggregate.Store entity);
    }
}