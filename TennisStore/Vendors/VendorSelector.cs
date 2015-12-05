using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Domain.MasterData.VendorAggregate;

namespace TennisStore.Vendors
{
    public static class VendorSelector
    {
        public static Vendor Get(string vendorId)
        {
            if (string.IsNullOrEmpty(vendorId))
                throw new NotValidException(vendorId);

            Vendor vendor = ContextFactory.Create<IVendorContext>().Get(vendorId);
            if (vendor == null)
                throw new NotFoundException("Vendor", vendorId);

            return vendor;
        }

        public static List<Vendor> FindAll()
        {
            return ContextFactory.Create<IVendorContext>().FindAll();
        }
    }
}
