using AutoMapper;
using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.SearchInShoppingList
{
    public class SearchInShoppingListQueryHandler : IRequestHandler<SearchInShoppingListQueryRequest, IEnumerable<GetByParameterShoppingListDto>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMapper _mapper;
        public SearchInShoppingListQueryHandler(IShoppingListRepository shoppingListRepository, IMapper mapper)
        {
            _shoppingListRepository = shoppingListRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetByParameterShoppingListDto>> Handle(SearchInShoppingListQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _shoppingListRepository.Search(request.Parameters);

            return _mapper.Map<List<GetByParameterShoppingListDto>>(result);

        }
    }
}
