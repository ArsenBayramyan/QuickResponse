using FluentValidation;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Validation
{
    public class PostCreateValidator:AbstractValidator<PostCreateModel>
    {
        public PostCreateValidator()
        {
            this.RuleFor(p => p.PostName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post Name should be not empty.")
                .Length(10,50 );
            this.RuleFor(p => p.Body)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post's body should be not empty.")
                .Length(10, 100);
            this.RuleFor(p => p.ProductType.ProductTypeName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Product type name should be not empty.")
                .Length(2, 20);
            this.RuleFor(p => p.ProductType.Dimensionality)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Dimensionality of product should be not empty.")
                .Length(2, 20);
            this.RuleFor(p => p.PostType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post type should be not empty.")
                .Length(2, 20);
            this.RuleFor(p => p.PostDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Post date should be not empty.");
        }
    }
}
