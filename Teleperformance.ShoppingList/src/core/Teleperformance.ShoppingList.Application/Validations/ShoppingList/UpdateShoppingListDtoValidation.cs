using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;

namespace Teleperformance.Bootcamp.Application.Validations.ShoppingList
{
    public class UpdateShoppingListDtoValidation :AbstractValidator<UpdateShoppingListDto>
    {
        public UpdateShoppingListDtoValidation()
        {
            RuleFor(x => x.Title)
              .Length(2, 30).WithMessage("Başlık geçerli uzunlukta değil")
              .NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Description)
                .MaximumLength(100).WithMessage("Açıklama 100 karakterden uzun olamaz");
        }
    }
}
