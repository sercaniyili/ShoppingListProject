using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserCreate;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserLogin;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Persistence.Repositories;

namespace Teleperformance.Bootcamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMediator _mediator;
        public UserController(IMediator mediator, IAppUserRepository appUserRepository) =>(_mediator, _appUserRepository) = (mediator, appUserRepository);


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserCreateCommandRequest request)
        {
             var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
