using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserCreate;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate
{
    public class ShoppingListCreateCommandHandler : IRequestHandler<ShoppingListCreateCommandRequest, BaseResponse>
    {

        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        private readonly ICategoryRepository _categoryRepository ;
        private readonly IAppUserRepository  _appUserRepository;
        public ShoppingListCreateCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper, ICategoryRepository categoryRepository, IAppUserRepository appUserRepository)
        {
            _mapper = mapper;
            _shoppingListRepsitory = shoppingListRepsitory;
            _categoryRepository = categoryRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task<BaseResponse> Handle(ShoppingListCreateCommandRequest request, CancellationToken cancellationToken)
        {

                var result =  _mapper.Map<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>(request.CreateShoppingListDto);

                CreateShoppingListDtoValidation validation = new CreateShoppingListDtoValidation();
                validation.ValidateAndThrow(request.CreateShoppingListDto);

                var category = await _categoryRepository.GetByIdAsync(request.CreateShoppingListDto.CategoryId);
                var user = await _appUserRepository.GetByIdAsync(request.CreateShoppingListDto.AppUserId);

                result.Category = category;
                result.AppUser = user;

                await _shoppingListRepsitory.AddAsync(result);

                return new BaseResponse("Liste başarıyla eklendi", true);                                  
        }
    }
}


