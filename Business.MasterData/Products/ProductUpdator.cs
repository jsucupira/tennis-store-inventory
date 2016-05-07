using System;
using System.ComponentModel.Composition;
using System.Security.Permissions;
using Business.Contracts.Product;
using Business.MasterData.Vendors;
using Core.Common.Exceptions;
using Core.Common.Helpers;
using Core.Common.Model;
using Core.Common.Security;
using Core.Common.Service;
using Data.Contracts;
using Data.Contracts.Product;
using Domain.MasterData.ProductAggregate;
using Domain.MasterData.VendorAggregate;

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
    internal class ProductUpdator : UpdatorBase<Product, string>, IProductUpdator
    {

        [ImportingConstructor]
        public ProductUpdator(IProductRepository productRepository, IArchiverRepository archiverRepository, IQueueRepository queueRepository): base(productRepository, archiverRepository, queueRepository)
        {
        }

        /// <summary>
        ///     Creates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Product.</returns>
        Product IProductUpdator.Create(Product product)
        {
            if (product != null && string.IsNullOrEmpty(product.Id))
                product.Id = Guid.NewGuid().ToString();

            return Create(product);
        }

        /// <summary>
        ///     Deletes the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void IProductUpdator.Delete(string productId)
        {
            Delete(productId);
        }

        /// <summary>
        ///     Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void IProductUpdator.Update(Product product)
        {
            Update(product);
        }
    }
}