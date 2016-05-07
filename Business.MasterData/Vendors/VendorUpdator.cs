using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Vendor;
using Core.Common.Exceptions;
using Core.Common.Security;
using Data.Contracts;
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
    internal class VendorUpdator : UpdatorBase<Vendor, string>, IVendorUpdator
    {

        [ImportingConstructor]
        public VendorUpdator(IVendorRepository vendorRepository, IArchiverRepository archiverRepository, IQueueRepository queueRepository) : base(vendorRepository, archiverRepository, queueRepository)
        {
        }

        /// <summary>
        ///     Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Vendor.</returns>
        Vendor IVendorUpdator.Create(Vendor entity)
        {
            return base.Create(entity);
        }

        /// <summary>
        ///     Deletes the specified entity identifier.
        /// </summary>
        /// <param name="vendorId">The entity identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void IVendorUpdator.Delete(string vendorId)
        {
            base.Delete(vendorId);
        }

        /// <summary>
        ///     Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void IVendorUpdator.Update(Vendor entity)
        {
            base.Update(entity);
        }
    }
}