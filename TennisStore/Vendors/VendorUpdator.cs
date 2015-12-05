using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Domain.MasterData.VendorAggregate;

namespace TennisStore.Vendors
{
    /// <summary>
    /// Class VendorUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    public static class VendorUpdator
    {
        /// <summary>
        /// Creates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns>Vendor.</returns>
        public static Vendor Create(Vendor vendor)
        {
            vendor.ModifiedBy(ServiceBase.GetUserName());
            vendor.Validate();
            return ContextFactory.Create<IVendorContext>().Create(vendor);
        }

        /// <summary>
        /// Deletes the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <exception cref="NotValidException"></exception>
        public static void Delete(string vendorId)
        {
            if (string.IsNullOrEmpty(vendorId))
                throw new NotValidException(vendorId);

            ContextFactory.Create<IVendorContext>().Delete(vendorId);
        }

        /// <summary>
        /// Updates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        public static void Update(Vendor vendor)
        {
            vendor.ModifiedBy(ServiceBase.GetUserName());
            vendor.Validate();
            ContextFactory.Create<IVendorContext>().Update(vendor);
        }
    }
}