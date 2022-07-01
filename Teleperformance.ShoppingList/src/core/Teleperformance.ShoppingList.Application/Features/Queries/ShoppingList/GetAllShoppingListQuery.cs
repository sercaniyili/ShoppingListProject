using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList
{
    public class GetAllShoppingListQuery : IRequest<List<GelAllShoppingListDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
