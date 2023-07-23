using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).MaximumLength(100);

            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice)
                .GreaterThanOrEqualTo(5)
                .When(p=>p.CategoryId==3)
                .WithMessage("Kategori ID'si 3 olan ürünler en az 5 birim fiyat olmalıdır.");

            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.CategoryId).NotEmpty();
        }

        private bool StartWithMoon(string arg)
        {
            return arg.StartsWith("Moon");
        }
    }
}
