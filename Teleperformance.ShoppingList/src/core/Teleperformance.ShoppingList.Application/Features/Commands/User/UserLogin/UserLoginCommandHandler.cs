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
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, ServiceResponse<string>>
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

        public async Task<ServiceResponse<string>> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) new ServiceResponse<string>(string.Empty, "Kullanıcı bulunamadı", false);

            var result = await _userManager.CheckPasswordAsync(user, request.Password.Trim());

            var newUser = _mapper.Map<AppUser>(request);

            if (result)
            {
                var token = await _tokenGenerator.GenerateToken(user);
                return new ServiceResponse<string>(token ,"Giriş Başarılı", true);
            }
            return new ServiceResponse<string>(string.Empty,"Giriş Başarısız", true);
        }
    }
}
