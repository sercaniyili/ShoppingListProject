using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList
{
    public class GetAllShoppingListQueryHandler : IRequestHandler<GetAllShoppingListQuery, List<GelAllShoppingListDto>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMapper _mapper;

        public GetAllShoppingListQueryHandler(IShoppingListRepository shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public async Task<List<GelAllShoppingListDto>> Handle(GetAllShoppingListQuery request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListRepository.GetAll().Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(x=> x.Products)
                .Include(y=> y.AppUser)
                .ToListAsync();

            return _mapper.Map<List<GelAllShoppingListDto>>(result);

        }
    }
}
