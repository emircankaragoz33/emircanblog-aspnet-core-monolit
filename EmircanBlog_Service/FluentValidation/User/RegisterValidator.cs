using EmircanBlog_Entity.Entities;
using EmircanBlog_Entity.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.FluentValidation.User
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail boş olmamalı.").Length(5, 15).WithMessage("Mail adresi 40 haneyi geçemez.").EmailAddress().WithMessage("Mail adresi formatı olmalıdır.");
            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre zorunlu.")
            .Length(8, 100).WithMessage("Password must be between 8 and 100 characters.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        }
    }
}
