using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListDelete;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListUpdateIsComplete;
using Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetAllShoppingList;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.GetShoppingListById;
using Teleperformance.Bootcamp.Application.Features.Queries.ShoppingList.SearchInShoppingList;
using Teleperformance.Bootcamp.Application.Interfaces.Cache;
using Teleperformance.Bootcamp.Application.Interfaces.Contract;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;

namespace Teleperformance.Bootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        const string key = "shoppingList";

        private readonly IMediator _mediator;
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IRedisDistrubutedCache _redisDistrubutedCache;
        private readonly IMongoConnect _mongoDbConnect;

        public ShoppingListController(IMediator mediator, IShoppingListRepository shoppingListRepository, IRedisDistrubutedCache redisDistrubutedCache, IMongoConnect mongoDbConnect)

            => (_mediator, _shoppingListRepository, _redisDistrubutedCache, _mongoDbConnect)
            = (mediator, shoppingListRepository, redisDistrubutedCache, mongoDbConnect);


        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllShoppingLists([FromQuery] GetAllShoppingListQueryRequest request)
        {
          

            var result = await _mediator.Send(request);

            //  var cachedResult = await _redisDistrubutedCache.GetObjectAsync<GetAllShoppingListQueryRequest>(key);

            // await _redisDistrubutedCache.SetObjectAsync(key, result,2,60);             

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchInShoppingList([FromQuery] SearchInShoppingListQueryRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.Any())
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingListById(string id)
        {
            var request = new GetShoppingListByIdRequest { Id = id };
            var result = await _mediator.Send(request);

            if (result != null)
                return Ok(result);
            else
                return BadRequest(result);
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

        [HttpPut("ısComplete")]
        public async Task<IActionResult> UpdateShoppingListIsComplete([FromBody] ShoppingListUpdateIsCompleteCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
        public const string ShoppingListCollection = "CompletedLists";

        //[HttpGet]
        //public async Task<IActionResult> GetAllComletedShoppingList()
        //{
        //    var collection = _mongoDbConnect.ConnectToMongo<ShoppingListToBsonDto>(ShoppingListCollection);
        //    var result = await collection.Fi
        //    return result.ToList();
        //}

    }
}
