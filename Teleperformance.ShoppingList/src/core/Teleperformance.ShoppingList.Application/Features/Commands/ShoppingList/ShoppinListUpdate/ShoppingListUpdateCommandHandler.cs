using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate
{
    public class ShoppingListUpdateCommandHandler : IRequestHandler<ShoppingListUpdateCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        private readonly ICategoryRepository _categoryRepository;
        public ShoppingListUpdateCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _shoppingListRepsitory = shoppingListRepsitory;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse> Handle(ShoppingListUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>(request.updateShoppingListDto);

            var category = await _categoryRepository.GetByIdAsync(request.updateShoppingListDto.CategoryId);
           
            result.Category = category;

            if (result != null)
            {
                await _shoppingListRepsitory.UpdateAsync(result);
                return new BaseResponse("Liste başarıyla eklendi", true);
            }
            else
                return new BaseResponse("Liste ekleme başarısız", false);        
           
        }
    }
}
