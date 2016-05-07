using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Vendor;
using Core.Common.Exceptions;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Data.Contracts.Vendor;
using Domain.MasterData.VendorAggregate;

namespace Business.MasterData.Vendors
{
    /// <summary>
    ///     Class VendorUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [Export(typeof(IVendorUpdator))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class VendorUpdator : IVendorUpdator
    {
        private readonly IVendorRepository _vendorRepository;

        [ImportingConstructor]
        public VendorUpdator(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        /// <summary>
        ///     Creates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        /// <returns>Vendor.</returns>
        public Vendor Create(Vendor vendor)
        {
            if (_vendorRepository.Get(vendor.Id) != null)
                CreateErrors.ItemAlreadyExists(vendor.Id);

            vendor.ModifiedBy(ServiceBase.GetUserName());
            vendor.Validate();
            vendor.Activate();
            return _vendorRepository.Create(vendor);
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

            _vendorRepository.Delete(vendorId);
        }

        /// <summary>
        ///     Updates the specified vendor.
        /// </summary>
        /// <param name="vendor">The vendor.</param>
        public void Update(Vendor vendor)
        {
            vendor.ModifiedBy(ServiceBase.GetUserName());
            vendor.Validate();
            _vendorRepository.Update(vendor);
        }
    }
}