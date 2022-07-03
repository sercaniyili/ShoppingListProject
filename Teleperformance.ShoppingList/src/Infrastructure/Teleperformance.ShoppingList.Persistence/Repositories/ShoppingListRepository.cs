using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common;
using Teleperformance.Bootcamp.Domain.Entities;
using Teleperformance.Bootcamp.Persistence.Context;

namespace Teleperformance.Bootcamp.Persistence.Repositories
{
    public class ShoppingListRepository : GenericRepository<ShoppingList>, IShoppingListRepository
    {
        private readonly AppDbContext _appDbContext;
        public ShoppingListRepository(AppDbContext appDbContext) : base(appDbContext)
        { 
            _appDbContext = appDbContext;   
        }

        public async Task<IEnumerable<ShoppingList>> Search(SearchQueryParameters parameters)
        {
            IQueryable<ShoppingList> query = _appDbContext.ShoppingLists ;

            if (!string.IsNullOrWhiteSpace(parameters.ListName))
            {
                query = query.Where(x => x.Title.Contains(parameters.ListName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(parameters.CategoryName))
            {
                query = query.Where(x => x.Category.Name.Contains(parameters.CategoryName.ToLower()));
            }

            if (parameters.CreateDate.HasValue || parameters.CompleteDate.HasValue)
            {
                query = query.Where(x => x.CreateDate.Equals(parameters.CreateDate.HasValue) 
                || x.CompleteDate.Equals(parameters.CompleteDate.Value));
            }

            return query.ToList();
        }
    }
}
