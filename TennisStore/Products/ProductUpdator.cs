using System;
using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Helpers;
using Core.Common.Model;
using Core.Common.Security;
using Core.Common.Service;
using Domain.MasterData.ProductAggregate;

namespace TennisStore.Products
{
    /// <summary>
    ///     Class ProductUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    public static class ProductUpdator
    {
        /// <summary>
        ///     Creates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Product.</returns>
        public static Product Create(Product product)
        {
            IProductContext context = ContextFactory.Create<IProductContext>();
            if (context.Get(product.Id) != null)
                CreateErrors.ItemAlreadyExists(product.Id);

            product.ModifiedBy(ServiceBase.GetUserName());
            product.Validate();
            product.Activate();
            return ContextFactory.Create<IProductContext>().Create(product);
        }

        /// <summary>
        ///     Deletes the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="NotValidException"></exception>
        public static void Delete(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                CreateErrors.NotValid(productId, nameof(productId));

            IProductContext context = ContextFactory.Create<IProductContext>();
            Product product = context.Get(productId);

            if (product != null)
            {
                product.ModifiedBy(ServiceBase.GetUserName());
                product.DeActivate();
                context.Update(product);
            }
        }

        /// <summary>
        ///     Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public static void Update(Product product)
        {
            product.ModifiedBy(ServiceBase.GetUserName());
            product.Validate();
            ContextFactory.Create<IProductContext>().Update(product);
        }
    }
}