using FluentValidation;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Validation
{
    public class ProductCreateValidator:AbstractValidator<ProductTypeCreateModel>
    {
        public ProductCreateValidator()
        {
            this.RuleFor(p => p.ProductTypeName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Product type name should be not empty.");
            this.RuleFor(p => p.Dimensionality)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Product type dimensionality should be not empty.");
        }
    }
}
