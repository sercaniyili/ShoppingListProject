using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate
{
    public class ShoppingListUpdateCommandRequest : IRequest<BaseResponse>
    {
        public UpdateShoppingListDto UpdateShoppingListDto { get; set; }
    }
}
