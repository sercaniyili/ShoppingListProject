using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Bootcamp.Application.Features.Commands.Products.AddProduct;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator, IProductRepository productRepository)
            =>(_mediator, _productRepository)=(mediator, productRepository);

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] AddProductCommandRequest request)
        {

            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
