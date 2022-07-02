using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate
{
    public class ShoppingListCreateCommandRequest:IRequest<BaseResponse>
    {
        public CreateShoppingListDto CreateShoppingListDto { get; set; }
    }
}
