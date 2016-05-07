using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Permissions;
using Business.Contracts.Product;
using Core.Common.Exceptions;
using Core.Common.Security;
using Data.Contracts.Product;
using Domain.MasterData.ProductAggregate;

namespace Business.MasterData.Products
{
    /// <summary>
    ///     Class ProductSelector.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.SYS_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_VIEW)]
    [Export(typeof(IProductSelector))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ProductSelector : IProductSelector
    {
        private readonly IProductReadOnlyRepository _productRepository;

        [ImportingConstructor]
        public ProductSelector(IProductReadOnlyRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Product&gt;.</returns>
        public List<Product> FindAll(bool active)
        {
            return _productRepository.FindAll().Where(t => t.IsActive == active).ToList();
        }

        /// <summary>
        ///     Gets the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>Product.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Product</exception>
        public Product Get(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new NotValidException(productId);

            Product product = _productRepository.Get(productId);
            if (product == null)
                CreateErrors.NotFound(productId);

            return product;
        }
    }
}