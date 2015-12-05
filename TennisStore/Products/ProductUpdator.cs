using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Helpers;
using Domain.MasterData.ProductAggregate;

namespace TennisStore.Products
{
    public static class ProductUpdator
    {
        public static Product Create(Product product)
        {
            product.Validate();
            return ContextFactory.Create<IProductContext>().Create(product);
        }

        public static void Delete(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new NotValidException(productId);

            ContextFactory.Create<IProductContext>().Delete(productId);
        }

        public static void Update(Product product)
        {
            product.Validate();
            ContextFactory.Create<IProductContext>().Update(product);
        }
    }
}