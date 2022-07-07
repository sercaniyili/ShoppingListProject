using AutoMapper;
using FluentValidation;
using MediatR;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Validations.Product;
using Teleperformance.Bootcamp.Domain.Common.Response;
using Teleperformance.Bootcamp.Domain.Entities;

namespace Teleperformance.Bootcamp.Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper, IShoppingListRepository shoppingListRepsitory)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _shoppingListRepsitory = shoppingListRepsitory;
        }

        public async Task<BaseResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Product>(request.AddProductDto);

            AddProductDtoValidation validation = new AddProductDtoValidation();
            validation.ValidateAndThrow(request.AddProductDto);

            var shoppingList = await _shoppingListRepsitory.GetByIdAsync(request.AddProductDto.ShoppingListId);

            result.ShoppingListId = shoppingList.Id;

            await _productRepository.AddAsync(result);

            return new BaseResponse("Ürün başarıyla eklendi", true);
        }
    }
}
