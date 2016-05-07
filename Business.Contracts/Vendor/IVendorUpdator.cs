using Core.Common.Exceptions;

namespace Business.Contracts.Vendor
{
    public interface IVendorUpdator
    {
        /// <summary>
        ///     Creates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns>Vendor.</returns>
        Domain.MasterData.VendorAggregate.Vendor Create(Domain.MasterData.VendorAggregate.Vendor vendor);

        /// <summary>
        ///     Deletes the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void Delete(string vendorId);

        /// <summary>
        ///     Updates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        void Update(Domain.MasterData.VendorAggregate.Vendor vendor);
    }
}