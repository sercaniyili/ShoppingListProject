using MediatR;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete
{
    public class ShoppingListCreateCommandHandler : IRequestHandler<ShoppingListDeleteCommandRequest, BaseResponse>
    {
        private readonly IShoppingListRepository _shoppingListRepsitory;

        public ShoppingListCreateCommandHandler(IShoppingListRepository shoppingListRepsitory)
            => _shoppingListRepsitory = shoppingListRepsitory;

        public async Task<BaseResponse> Handle(ShoppingListDeleteCommandRequest request, CancellationToken cancellationToken)
        {

            await _shoppingListRepsitory.DeleteAsync(request.Id);

            return new BaseResponse("Silme işlemi başarılı", true);
        }
    }
}
