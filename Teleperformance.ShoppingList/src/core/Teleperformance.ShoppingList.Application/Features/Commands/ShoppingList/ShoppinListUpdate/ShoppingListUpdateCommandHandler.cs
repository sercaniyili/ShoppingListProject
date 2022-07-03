using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate
{
    public class ShoppingListUpdateCommandHandler : IRequestHandler<ShoppingListUpdateCommandRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        public ShoppingListUpdateCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper)
        {
            _shoppingListRepsitory = shoppingListRepsitory;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ShoppingListUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListRepsitory.GetByIdAsync(request.updateShoppingListDto.Id);

            var asd = _mapper.Map(request.updateShoppingListDto,result);

            await _shoppingListRepsitory.UpdateAsync(asd);

            return Unit.Value;
        }
    }
}
