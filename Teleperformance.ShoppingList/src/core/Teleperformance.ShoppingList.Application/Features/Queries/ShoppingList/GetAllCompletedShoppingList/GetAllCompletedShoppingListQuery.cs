using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;

namespace Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllCompletedShoppingList
{
    public class GetAllCompletedShoppingListQuery : IRequest<List<ShoppingListToBsonDto>>
    {
    }
}
