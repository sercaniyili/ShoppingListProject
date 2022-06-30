using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.User;

namespace Teleperformance.Bootcamp.Application.Validations.User
{
    public class UserLoginDtoValidation : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().MinimumLength(3).MaximumLength(30)
                .WithMessage("Kullanıcı adını lütfen kurallara uygun giriniz");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş geçilemez");
        }

    }
}
