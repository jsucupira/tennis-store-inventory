using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Permissions;
using Core.Common.Exceptions;
using Core.Common.Security;
using Core.Common.Service;
using Data.Contracts;
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
    public class ProductSelector
    {
        private readonly IProductContext _productContext;

        [ImportingConstructor]
        public ProductSelector(IProductContext productContext)
        {
            _productContext = productContext;
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns>List&lt;Product&gt;.</returns>
        public List<Product> FindAll()
        {
            return _productContext.FindAll().Where(t => t.IsActive).ToList();
        }

        /// <summary>
        /// Gets the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Product.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Product</exception>
        public Product Get(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new NotValidException(productId);

            Product product = _productContext.Get(productId);
            if (product == null)
                CreateErrors.NotFound(productId);

            return product;
        }
    }
}