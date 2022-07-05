using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.SearchInShoppingList
{
    public class SearchInShoppingListQueryRequest : IRequest<IEnumerable<GetByParameterShoppingListDto>>
    {
        public SearchQueryParameters Parameters { get; set; }
    }
}
