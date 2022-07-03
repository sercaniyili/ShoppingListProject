using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;
using Teleperformance.Bootcamp.Domain.Entities;

namespace Teleperformance.Bootcamp.Application.Interfaces.Repositories
{
    public interface IShoppingListRepository: IGenericRepository<ShoppingList>
    {
        Task<IEnumerable<ShoppingList>> Search(SearchQueryParameters parameters);
    }
}
