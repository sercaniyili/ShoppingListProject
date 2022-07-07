using Teleperformance.Bootcamp.Domain.Common;
using Teleperformance.Bootcamp.Domain.Entities;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IShoppingListRepository : IGenericRepository<ShoppingList>
    {
        Task<IEnumerable<ShoppingList>> Search(SearchQueryParameters parameters);
    }
}
