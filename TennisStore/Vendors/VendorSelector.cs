using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Security;
using Domain.MasterData.VendorAggregate;

namespace TennisStore.Vendors
{
    /// <summary>
    /// Class VendorSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    public static class VendorSelector
    {
        /// <summary>
        /// Gets the specified vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>Vendor.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Vendor</exception>
        public static Vendor Get(string vendorId)
        {
            if (string.IsNullOrEmpty(vendorId))
                throw new NotValidException(vendorId);

            Vendor vendor = ContextFactory.Create<IVendorContext>().Get(vendorId);
            if (vendor == null)
                CreateErrors.NotFound(vendorId);

            return vendor;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>List&lt;Vendor&gt;.</returns>
        public static List<Vendor> FindAll()
        {
            return ContextFactory.Create<IVendorContext>().FindAll().Where(t => t.IsActive).ToList();
        }
    }
}
