using Core.Common.Exceptions;

namespace Business.Contracts.Vendor
{
    public interface IVendorUpdator
    {
        /// <summary>
        ///     Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Vendor.</returns>
        Domain.MasterData.VendorAggregate.Vendor Create(Domain.MasterData.VendorAggregate.Vendor entity);

        /// <summary>
        ///     Deletes the specified entity identifier.
        /// </summary>
        /// <param name="vendorId">The entity identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void Delete(string vendorId);

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(Domain.MasterData.VendorAggregate.Vendor entity);
    }
}