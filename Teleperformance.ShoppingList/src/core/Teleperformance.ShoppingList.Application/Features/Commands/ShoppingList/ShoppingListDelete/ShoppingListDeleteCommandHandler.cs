using FluentValidation;
using MediatR;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Application.Validations.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete
{
    public class ShoppingListDeleteCommandHandler : IRequestHandler<ShoppingListDeleteCommandRequest, BaseResponse>
    {
        private readonly IShoppingListRepository _shoppingListRepsitory;

        public ShoppingListDeleteCommandHandler(IShoppingListRepository shoppingListRepsitory)
            => _shoppingListRepsitory = shoppingListRepsitory;

        public async Task<BaseResponse> Handle(ShoppingListDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            ShoppingListDeleteCommandRequestValidation validation = new ShoppingListDeleteCommandRequestValidation();
            validation.ValidateAndThrow(request);

            await _shoppingListRepsitory.DeleteAsync(request.Id);

            return new BaseResponse("Silme işlemi başarılı", true);
        }
    }
}
