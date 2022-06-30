using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.User;

namespace Teleperformance.Bootcamp.Application.Validations.User
{
    public class UserCreateDtoValidation:AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidation()
        {
            RuleFor(x => x.FirstName)
                .Length(2,30);
            RuleFor(x => x.LastName)
                .Length(2, 30);
            RuleFor(x => x.Username)
                .Length(2, 30)
                .NotEmpty()
                .WithMessage("Kullanıcı adını lütfen kurallara uygun giriniz");
            RuleFor(x => x.Email)
                .EmailAddress()
                .MinimumLength(3)
                .MaximumLength(30)
                .WithMessage("Kullanıcı adını lütfen kurallara uygun giriniz");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş geçilemez");        
        }
    }
}
