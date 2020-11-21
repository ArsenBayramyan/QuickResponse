using FluentValidation;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Validation
{
    public class UserLoginValidator:AbstractValidator<UserLoginModel>
    {
        public UserLoginValidator()
        {
            this.RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email address is required");
            this.RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
