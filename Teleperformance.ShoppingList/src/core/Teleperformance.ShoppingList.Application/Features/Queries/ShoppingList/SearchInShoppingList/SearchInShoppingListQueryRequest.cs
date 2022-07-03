using MediatR;
using Teleperformance.Bootcamp.Domain.Common;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.SearchInShoppingList
{
    public class SearchInShoppingListQueryRequest : IRequest<IEnumerable<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>>
    {
        public SearchQueryParameters parameters { get; set; }
    }
}
