using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListUpdateIsComplete
{
    public class ShoppingListUpdateIsCompleteCommandHandler : IRequestHandler<ShoppingListUpdateIsCompleteCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        public ShoppingListUpdateIsCompleteCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper)
        {
            _shoppingListRepsitory = shoppingListRepsitory;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ShoppingListUpdateIsCompleteCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _shoppingListRepsitory.GetByIdAsync(request.UpdateIsCompleteDto.Id);

            entity = _mapper.Map(request.UpdateIsCompleteDto, entity);

            UpdateIsCompleteDtoValidation validation = new UpdateIsCompleteDtoValidation();
            validation.ValidateAndThrow(request.UpdateIsCompleteDto);

            if (entity != null)
            {
                _shoppingListRepsitory.Update(entity);
                return new BaseResponse("liste başarıyla tamalandı", true);
            }
            else
                return new BaseResponse("Liste tamamlama başarısız", false);
        }
    }
}
