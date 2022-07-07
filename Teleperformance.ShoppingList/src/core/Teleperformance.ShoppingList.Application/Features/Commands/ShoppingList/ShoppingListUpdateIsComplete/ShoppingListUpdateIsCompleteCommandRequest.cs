using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListUpdateIsComplete
{
    public class ShoppingListUpdateIsCompleteCommandRequest : IRequest<BaseResponse>
    {
        public UpdateIsCompleteDto UpdateIsCompleteDto { get; set; }
    }
}
