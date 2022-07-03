using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.Products
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
