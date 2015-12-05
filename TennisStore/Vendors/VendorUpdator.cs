using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Helpers;
using Domain.MasterData.VendorAggregate;

namespace TennisStore.Vendors
{
    public static class VendorUpdator
    {
        public static Vendor Create(Vendor vendor)
        {
            vendor.Validate();
            return ContextFactory.Create<IVendorContext>().Create(vendor);
        }

        public static void Delete(string vendorId)
        {
            if (string.IsNullOrEmpty(vendorId))
                throw new NotValidException(vendorId);

            ContextFactory.Create<IVendorContext>().Delete(vendorId);
        }

        public static void Update(Vendor vendor)
        {
            vendor.Validate();
            ContextFactory.Create<IVendorContext>().Update(vendor);
        }
    }
}