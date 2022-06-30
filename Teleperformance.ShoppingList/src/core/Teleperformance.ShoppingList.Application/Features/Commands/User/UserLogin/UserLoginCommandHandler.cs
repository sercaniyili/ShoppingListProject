using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Token;
using Teleperformance.Bootcamp.Domain.Common.Response;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Application.Features.Commands.User.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;
        public UserLoginCommandHandler(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }


        public async Task<BaseResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(request.Email);

            if (user == null) new BaseResponse("Kullanıcı bulunamadı", false);

            var result = await _userManager.CheckPasswordAsync(user, request.Password.Trim());

            var newUser = _mapper.Map<AppUser>(request);

            if (result)
            {   
                var token = _tokenGenerator.GenerateToken(user);
                return new BaseResponse("Giriş Başarılı", true);
            }
            return new BaseResponse("Giriş Başarılı", true);
        }
    }
}
