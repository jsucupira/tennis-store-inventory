namespace Data.Contracts.Product
{
    public interface IProductRepository: IRepository<Domain.MasterData.ProductAggregate.Product, string>
    {
    }
}