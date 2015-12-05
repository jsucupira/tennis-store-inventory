using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Factories;
using Core.Common.Security;
using Core.Common.Service;
using Domain.MasterData.ProductAggregate;

namespace TennisStore.Products
{
    /// <summary>
    /// Class ProductSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    public static class ProductSelector
    {
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>List&lt;Product&gt;.</returns>
        public static List<Product> FindAll()
        {
            return ContextFactory.Create<IProductContext>().FindAll().Where(t => t.IsActive).ToList();
        }

        /// <summary>
        /// Gets the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Product.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Product</exception>
        public static Product Get(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new NotValidException(productId);

            Product product = ContextFactory.Create<IProductContext>().Get(productId);
            if (product == null)
                CreateErrors.NotFound(productId);

            return product;
        }
    }
}