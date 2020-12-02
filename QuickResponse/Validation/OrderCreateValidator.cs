using FluentValidation;
using QuickResponse.Models.ViewModels;
using System;

namespace QuickResponse.Validation
{
    public class OrderCreateValidator:AbstractValidator<OrderCreateModel>
    {
        public OrderCreateValidator()
        {
            this.RuleFor(o => o.ProductCount)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Product count should be not empty.")
                .Must((o, list, context) =>
                {
                    if (o.ProductCount.ToString() != "")
                    {
                        context.MessageFormatter.AppendArgument("ProductCount", o.ProductCount);
                        return Int32.TryParse(o.ProductCount.ToString(), out int number);
                    }
                    return true;
                })
                .WithMessage("Number of trainings must be a number.")
                .GreaterThan(0).WithMessage("Number of trainings must be greater than 0.");
        }
    }
}
