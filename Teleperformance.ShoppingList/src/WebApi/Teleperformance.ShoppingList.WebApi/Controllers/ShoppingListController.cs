using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllShoppingList;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetShoppingListById;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.SearchInShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Cache;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IMediator _mediator;
        private readonly IRedisDistrubutedCache _redisDistrubutedCache;
        public ShoppingListController(IMediator mediator, IShoppingListRepository shoppingListRepository, IRedisDistrubutedCache redisDistrubutedCache) => 
            (_mediator, _shoppingListRepository, _redisDistrubutedCache) = (mediator, shoppingListRepository, redisDistrubutedCache);


        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllShoppingLists([FromQuery] GetAllShoppingListQueryRequest request)
        {
            const string key = "shoppingList";

            var result = await _mediator.Send(request);

          //  var cachedResult = await _redisDistrubutedCache.GetObjectAsync<GetAllShoppingListQueryRequest>(key);

           // await _redisDistrubutedCache.SetObjectAsync(key, result,2,60);             

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchInShoppingListQueryRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Any())
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingListById( string id)
        {
            var request = new GetShoppingListByIdRequest { Id = id };
            var result = await _mediator.Send(request);

            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateShoppingList([FromBody] CreateShoppingListDto CreateShoppingListDto)
        //{
        //    var command = new ShoppingListCreateCommandRequest { CreateShoppingListDto = CreateShoppingListDto };
        //    var result = await _mediator.Send(command);

        //    if (result.IsSuccess)
        //        return Ok(result);
        //    else
        //        return BadRequest(result);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] ShoppingListCreateCommandRequest request)
        {
           
            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingList([FromQuery] ShoppingListDeleteCommandRequest request)
        {

            var result = await _mediator.Send(request);

            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateShoppingList([FromBody] ShoppingListUpdateCommandRequest request)
        {

            var result = await _mediator.Send(request);
                
            return Ok(result);
          
        }




    }
}
