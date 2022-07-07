using MediatR;
using Teleperformance.Bootcamp.Application.DTOs.Products;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.Products.AddProduct
{
    public class AddProductCommandRequest : IRequest<BaseResponse>
    {
        public AddProductDto AddProductDto { get; set; }
    }
}
