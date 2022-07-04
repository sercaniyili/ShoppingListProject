using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate
{
    public class ShoppingListUpdateCommandRequest :IRequest<BaseResponse>
    {
        public UpdateShoppingListDto UpdateShoppingListDto { get; set; }
    }
}
