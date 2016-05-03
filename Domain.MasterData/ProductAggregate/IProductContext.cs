using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Service;
using Data.Contracts;

namespace Domain.MasterData.ProductAggregate
{
    public interface IProductContext : IServices<Product, string>
    {
    }
}
