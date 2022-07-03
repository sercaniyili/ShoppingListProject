using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllShoppingList
{
    public class GetAllShoppingListQueryRequest : IRequest<List<GetAllShoppingListDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
