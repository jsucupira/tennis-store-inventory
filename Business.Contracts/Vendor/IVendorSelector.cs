using System.Collections.Generic;
using Core.Common.Exceptions;

namespace Business.Contracts.Vendor
{
    public interface IVendorSelector
    {
        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Vendor&gt;.</returns>
        List<Domain.MasterData.VendorAggregate.Vendor> FindAll(bool active);

        /// <summary>
        ///     Gets the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Vendor.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Vendor</exception>
        Domain.MasterData.VendorAggregate.Vendor Get(string vendorId);
    }
}