using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMediator _mediator;
        public ShoppingListController(IMediator mediator, IShoppingListRepository shoppingListRepository) => (_mediator, _shoppingListRepository) = (mediator, shoppingListRepository);


        [HttpGet]
        public async Task<IActionResult> GetAllShoppingLists([FromQuery]GetAllShoppingListQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
