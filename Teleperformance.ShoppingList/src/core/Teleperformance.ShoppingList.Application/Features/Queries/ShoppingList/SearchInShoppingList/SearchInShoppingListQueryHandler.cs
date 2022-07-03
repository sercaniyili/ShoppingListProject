using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.SearchInShoppingList
{
    public class SearchInShoppingListQueryHandler : IRequestHandler<SearchInShoppingListQueryRequest, IEnumerable<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        public SearchInShoppingListQueryHandler(IShoppingListRepository shoppingListRepository)
        {
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<IEnumerable<Domain.Entities.ShoppingList>> Handle(SearchInShoppingListQueryRequest request, CancellationToken cancellationToken)
        {
           return await _shoppingListRepository.Search(request.parameters);               
            
        }
    }
}
