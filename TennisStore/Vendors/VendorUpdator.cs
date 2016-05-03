using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Domain.MasterData.VendorAggregate;

namespace TennisStore.Vendors
{
    /// <summary>
    ///     Class VendorUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    public class VendorUpdator
    {
        private readonly IVendorContext _vendorContext;

        public VendorUpdator(IVendorContext vendorContext)
        {
            _vendorContext = vendorContext;
        }

        /// <summary>
        ///     Creates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns>Vendor.</returns>
        public Vendor Create(Vendor vendor)
        {
            if (_vendorContext.Get(vendor.Id) != null)
                CreateErrors.ItemAlreadyExists(vendor.Id);

            vendor.ModifiedBy(ServiceBase.GetUserName());
            vendor.Validate();
            vendor.Activate();
            return _vendorContext.Create(vendor);
        }

        /// <summary>
        ///     Deletes the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <exception cref="NotValidException"></exception>
        public void Delete(string vendorId)
        {
            if (string.IsNullOrEmpty(vendorId))
                CreateErrors.NotValid(vendorId, nameof(vendorId));

            _vendorContext.Delete(vendorId);
        }

        /// <summary>
        ///     Updates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        public void Update(Vendor vendor)
        {
            vendor.ModifiedBy(ServiceBase.GetUserName());
            vendor.Validate();
            _vendorContext.Update(vendor);
        }
    }
}