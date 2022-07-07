using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllShoppingList
{
    public class GetAllShoppingListQueryRequest : IRequest<List<GetAllShoppingListDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
