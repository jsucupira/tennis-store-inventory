using System.Diagnostics.CodeAnalysis;

namespace Domain.CrossCutting.SalesInfo
{
    [ExcludeFromCodeCoverage]
    public class SalesTaxRate
    {
        public decimal TaxRate { get; set; }
        public string TaxType { get; set; }
    }
}