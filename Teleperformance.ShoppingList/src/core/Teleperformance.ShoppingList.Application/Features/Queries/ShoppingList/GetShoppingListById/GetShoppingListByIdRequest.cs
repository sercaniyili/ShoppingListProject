using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetShoppingListById
{
    public class GetShoppingListByIdRequest : IRequest<GetAllShoppingListDto>
    {
        public string Id { get; set; }
    }
}
