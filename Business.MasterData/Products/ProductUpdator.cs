using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Product;
using Core.Common.Exceptions;
using Core.Common.Helpers;
using Core.Common.Security;
using Core.Common.Service;
using Data.Contracts.Product;
using Domain.MasterData.ProductAggregate;

namespace Business.MasterData.Products
{
    /// <summary>
    ///     Class ProductUpdator.
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.ADMINISTRATOR)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_ADMIN)]
    [PrincipalPermission(SecurityAction.Demand, Role = SecurityGroups.MASTER_DATA_EDITOR)]
    [Export(typeof(IProductUpdator))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class ProductUpdator : IProductUpdator
    {
        private readonly IProductRepository _productContext;

        [ImportingConstructor]
        public ProductUpdator(IProductRepository productContext)
        {
            _productContext = productContext;
        }

        /// <summary>
        ///     Creates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Product.</returns>
        public Product Create(Product product)
        {
            if (_productContext.Get(product.Id) != null)
                CreateErrors.ItemAlreadyExists(product.Id);

            product.ModifiedBy(ServiceBase.GetUserName());
            product.Validate();
            product.Activate();
            return _productContext.Create(product);
        }

        /// <summary>
        ///     Deletes the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="NotValidException"></exception>
        public void Delete(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                CreateErrors.NotValid(productId, nameof(productId));

            Product product = _productContext.Get(productId);

            if (product != null)
            {
                product.ModifiedBy(ServiceBase.GetUserName());
                product.DeActivate();
                _productContext.Update(product);
            }
        }

        /// <summary>
        ///     Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        public void Update(Product product)
        {
            product.ModifiedBy(ServiceBase.GetUserName());
            product.Validate();
            _productContext.Update(product);
        }
    }
}