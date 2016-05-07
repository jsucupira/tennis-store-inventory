using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Permissions;
using Business.Contracts.Vendor;
using Core.Common.Exceptions;
using Core.Common.Security;
using Data.Contracts.Vendor;
using Domain.MasterData.VendorAggregate;

namespace Business.MasterData.Vendors
{
    /// <summary>
    ///     Class VendorSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    [Export(typeof(IVendorSelector))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class VendorSelector : SelectorBase<Vendor, string>, IVendorSelector
    {

        [ImportingConstructor]
        public VendorSelector(IVendorReadOnlyRepository vendorRepository): base(vendorRepository)
        {
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Vendor&gt;.</returns>
        List<Vendor> IVendorSelector.FindAll(bool active)
        {
            return FindAll(active);
        }

        /// <summary>
        ///     Gets the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Vendor.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Vendor</exception>
        Vendor IVendorSelector.Get(string vendorId)
        {
            return Get(vendorId);
        }
    }
}