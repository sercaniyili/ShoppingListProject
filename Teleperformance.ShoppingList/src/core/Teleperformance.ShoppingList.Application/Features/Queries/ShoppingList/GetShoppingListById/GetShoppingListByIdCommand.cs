using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetShoppingListById
{
    public class GetShoppingListByIdCommand : IRequestHandler<GetShoppingListByIdRequest, GetAllShoppingListDto>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMapper _mapper;

        public GetShoppingListByIdCommand(IShoppingListRepository shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public async Task<GetAllShoppingListDto> Handle(GetShoppingListByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetAllShoppingListDto>(result);
        }
    }
}
