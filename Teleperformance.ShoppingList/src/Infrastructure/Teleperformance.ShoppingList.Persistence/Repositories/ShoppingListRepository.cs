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
            IQueryable<ShoppingList> query =  _appDbContext.ShoppingLists.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Keyword))
            {
                query = query.Where(x => x.Title.Contains(parameters.Keyword.ToLower())
                ||  x.Category.Name.Contains(parameters.Keyword.ToLower()));
            }

            if (parameters.Date.HasValue || parameters.Date.HasValue)
            {
                query = query.Where(x => x.CreateDate.Equals(parameters.Date.HasValue) 
                || x.CompleteDate.Equals(parameters.Date.Value));
            }

            return query.ToList();
        }











    }
}
