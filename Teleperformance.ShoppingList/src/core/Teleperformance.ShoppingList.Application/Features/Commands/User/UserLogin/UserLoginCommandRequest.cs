using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.User;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.User.UserLogin
{
    public class UserLoginCommandRequest: IRequest<ServiceResponse<string>>
    {
        public UserLoginDto UserLoginDto { get; set; }
    }
}
