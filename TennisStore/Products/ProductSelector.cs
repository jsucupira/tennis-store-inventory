using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Domain.MasterData.ProductAggregate;

namespace TennisStore.Products
{
    public static class ProductSelector
    {
        public static Product Get(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new NotValidException(productId);

            Product product = ContextFactory.Create<IProductContext>().Get(productId);
            if (product == null)
                throw new NotFoundException("Product", productId);

            return product;
        }

        public static List<Product> FindAll()
        {
            return ContextFactory.Create<IProductContext>().FindAll();
        }
    }
}
