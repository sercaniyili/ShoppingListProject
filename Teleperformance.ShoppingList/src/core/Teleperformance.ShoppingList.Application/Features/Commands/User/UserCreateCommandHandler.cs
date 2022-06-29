using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.User;
using Teleperformance.Bootcamp.Domain.Common.Response;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Application.Features.Commands.User
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        public UserCreateCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
                return new BaseResponse("Kullanıcı bulunamadı",false);

            var newUser = _mapper.Map<AppUser>(request);
            
        
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
                return new BaseResponse("Kullanıcı oluşturulamadı", false);
            else
                return  new BaseResponse("Kullanıcı başarıyla oluşturuldu", true);
        }
    }
}
