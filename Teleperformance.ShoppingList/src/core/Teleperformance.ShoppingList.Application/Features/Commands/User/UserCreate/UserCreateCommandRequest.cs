using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.User;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.User.UserCreate
{
    public class UserCreateCommandRequest : IRequest<BaseResponse>
    {
        public UserCreateDto UserCreateDto { get; set; }
        }
    }
