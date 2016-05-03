using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Service;
using Data.Contracts;

namespace Domain.MasterData.VendorAggregate
{
    public interface IVendorContext : IServices<Vendor, string>
    {
    }
}
