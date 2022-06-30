using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Application.Interfaces.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(AppUser user);
    }
}
