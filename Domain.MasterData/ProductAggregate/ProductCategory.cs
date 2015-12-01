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

        public ProductCategory(string name)
            : this()
        {
            Name = name;
        }

        public string Name { get; private set; }

        protected override IValidator GetValidator()
        {
            return new ProductCategoryValidator();
        }
    }
}