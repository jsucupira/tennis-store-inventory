using Core.Common.Exceptions;

namespace Business.Contracts.Product
{
    public interface IProductUpdator
    {
        /// <summary>
        ///     Creates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Product.</returns>
        Domain.MasterData.ProductAggregate.Product Create(Domain.MasterData.ProductAggregate.Product product);

        /// <summary>
        ///     Deletes the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <exception cref="NotValidException"></exception>
        void Delete(string productId);

        /// <summary>
        ///     Updates the specified product.
        /// </summary>
        /// <param name="product">The product.</param>
        void Update(Domain.MasterData.ProductAggregate.Product product);
    }
}