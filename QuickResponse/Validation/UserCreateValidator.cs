using FluentValidation;
using QuickResponse.Models.ViewModels;

namespace QuickResponse.Validation
{
    public class UserCreateValidator:AbstractValidator<UserCreateModel>
    {
        public UserCreateValidator()
        {
            this.RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("First Name should be not empty.")
                .Length(2, 25);
            this.RuleFor(u => u.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last Name should be not empty.")
                .Length(2, 25);
            this.RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
            this.RuleFor(u => u.Gender)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Gender should be not empty.");
            this.RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .Matches("[A-Z]").WithMessage("The password must contain a capital letter")
                .Matches("[a-z]").WithMessage("The password must contain a lowercase letter")
                .Matches("[0-9]").WithMessage("The password must contain a digit")
                .Matches("[^a-zA-Z0-9]").WithMessage("The password must contain a symbol");
            this.RuleFor(u => u.ConfirmPassword)
                .Equal(u => u.Password)
                .WithMessage("Password do not Match");
        }
    }
}
