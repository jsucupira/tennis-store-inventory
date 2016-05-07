namespace Data.Contracts.Vendor
{
    public interface IVendorReadOnlyRepository : IReadOnlyRepository<Domain.MasterData.VendorAggregate.Vendor, string>
    {
    }
}