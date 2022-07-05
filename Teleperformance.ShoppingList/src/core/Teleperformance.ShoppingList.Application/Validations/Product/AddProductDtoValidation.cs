using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.Products;

namespace Teleperformance.Bootcamp.Application.Validations.Product
{
    public class AddProductDtoValidation : AbstractValidator<AddProductDto>
    {
        public AddProductDtoValidation() {

            RuleFor(x => x.Name)
                .Length(2, 30)
                .NotEmpty().WithMessage(" Ad boş geçilemez");
            RuleFor(x => x.ShoppingListId)
              .NotEmpty().WithMessage("Liste Id boş geçilemez");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Birim boş geçilemez");
        }

    }
}
