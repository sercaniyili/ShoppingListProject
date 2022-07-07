using MediatR;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete
{
    public class ShoppingListDeleteCommandRequest : IRequest<BaseResponse>
    {
        public string Id { get; set; }
    }
}
