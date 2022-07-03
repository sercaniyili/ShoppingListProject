using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete
{
    public class ShoppingListDeleteCommandRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
