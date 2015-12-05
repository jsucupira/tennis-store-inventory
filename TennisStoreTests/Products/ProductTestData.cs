using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CrossCutting.Products;
using Domain.MasterData.ProductAggregate;

namespace TennisStoreTests.Products
{
    public static class ProductTestData
    {
        public static readonly IReadOnlyList<Product> Products = new List<Product>
        {
            new Product("product_1", "This is the first Product", "First Product", 1, UnitMeasure.Centimeters, 25.00M, UnitMeasure.Kilograms),
            new Product("product_2", "This is the Second Product", "Second Product", 1, UnitMeasure.Centimeters, 35.00M, UnitMeasure.Kilograms),
            new Product("product_3", "This is the Third Product", "Third Product", 1, UnitMeasure.Centimeters, 23.00M, UnitMeasure.Kilograms),
            new Product("product_4", "This is the Fourth Product", "Fourth Product", 1, UnitMeasure.Centimeters, 55.00M, UnitMeasure.Kilograms),
            new Product("product_5", "This is the Fifth Product", "Fifth Product", 1, UnitMeasure.Centimeters, 28.00M, UnitMeasure.Kilograms),
        };
    }
}
