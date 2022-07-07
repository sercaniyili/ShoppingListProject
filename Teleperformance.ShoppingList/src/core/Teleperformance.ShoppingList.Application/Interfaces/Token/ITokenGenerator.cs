using Teleperformance.Bootcamp.Domain.Entities.Identity;

namespace Teleperformance.Bootcamp.Application.Interfaces.Token
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(AppUser user);
    }
}
