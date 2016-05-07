using System.Collections.Generic;
using Core.Common.Exceptions;

namespace Business.Contracts.Product
{
    public interface IProductSelector
    {
        /// <summary>
        ///     Finds all.
        /// </summary>
        /// <returns>List&lt;Product&gt;.</returns>
        List<Domain.MasterData.ProductAggregate.Product> FindAll(bool active);

        /// <summary>
        ///     Gets the specified product identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>Product.</returns>
        /// <exception cref="NotValidException"></exception>
        /// <exception cref="ResourceNotFoundException">Product</exception>
        Domain.MasterData.ProductAggregate.Product Get(string id);
    }
}