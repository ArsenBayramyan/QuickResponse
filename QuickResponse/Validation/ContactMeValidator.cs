using FluentValidation;
using QuickResponse.Models.ViewModels;

namespace QuickResponse.Validation
{
    public class ContactMeValidator : AbstractValidator<ContactViewModel>
    {
        public ContactMeValidator()
        {
            this.RuleFor(u => u.Name)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Name should be not empty.")
               .Length(2, 25);
            this.RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email address is required")
                .EmailAddress().WithMessage("A valid email is required");
            this.RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^[+]*[(]{0,1}[0-9]{1,3}[)]{0,1}[-\s\./0-9]*$").WithMessage("The password must contain a digit");
            this.RuleFor(x=>x.Message)
                .NotEmpty().WithMessage("Message is required");
        }
    }
}
