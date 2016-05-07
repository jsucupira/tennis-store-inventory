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
    internal class ProductSelector : SelectorBase<Product, string>, IProductSelector
    {
        [ImportingConstructor]
        public ProductSelector(IProductReadOnlyRepository productRepository): base(productRepository)
        {
        }

        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Product&gt;.</returns>
        List<Product> IProductSelector.FindAll(bool active)
        {
            return FindAll(active);
        }

        /// <summary>
        ///     Gets the specified product identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>Product.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Product</exception>
        Product IProductSelector.Get(string id)
        {
            return Get(id);
        }
    }
}