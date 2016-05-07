namespace Data.Contracts.Product
{
    public interface IProductReadOnlyRepository : IReadOnlyRepository<Domain.MasterData.ProductAggregate.Product, string>
    {
    }
}