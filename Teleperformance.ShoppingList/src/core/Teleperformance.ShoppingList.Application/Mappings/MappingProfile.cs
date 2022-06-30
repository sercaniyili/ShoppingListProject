using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.User;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserCreate;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Application.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<AppUser, UserCreateCommandRequest>().ReverseMap();
            CreateMap<AppUser, UserLoginDto>();




        }
    }
}
