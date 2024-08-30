using EmircanBlog_Entity.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.FluentValidation.User
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Mail adresi gereklidir.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre gereklidir.");

          
        }
    }
}
