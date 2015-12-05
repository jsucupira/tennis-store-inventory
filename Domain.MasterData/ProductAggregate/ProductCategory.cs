using Core.Common.Model;
using Domain.MasterData.Validations;
using FluentValidation;

namespace Domain.MasterData.ProductAggregate
{
    public sealed class ProductCategory : Entity<int>
    {
        private ProductCategory()
        {
        }

        public ProductCategory(int id, string name): this()
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }

        protected override IValidator GetValidator()
        {
            return new ProductCategoryValidator();
        }
    }
}