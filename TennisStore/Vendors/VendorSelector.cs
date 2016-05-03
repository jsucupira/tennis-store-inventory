using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Security;
using Domain.MasterData.VendorAggregate;

namespace TennisStore.Vendors
{
    /// <summary>
    ///     Class VendorSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    public class VendorSelector
    {
        private readonly IVendorContext _vendorContext;

        [ImportingConstructor]
        public VendorSelector(IVendorContext vendorContext)
        {
            _vendorContext = vendorContext;
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Vendor&gt;.</returns>
        public List<Vendor> FindAll()
        {
            return _vendorContext.FindAll().Where(t => t.IsActive).ToList();
        }

        /// <summary>
        ///     Gets the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Vendor.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Vendor</exception>
        public Vendor Get(string vendorId)
        {
            if (string.IsNullOrEmpty(vendorId))
                throw new NotValidException(vendorId);

            Vendor vendor = _vendorContext.Get(vendorId);
            if (vendor == null)
                CreateErrors.NotFound(vendorId);

            return vendor;
        }
    }
}