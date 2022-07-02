using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllShoppingList;
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
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllShoppingLists([FromQuery] GetAllShoppingListQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] ShoppingListCreateCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);

        }

    }
}
