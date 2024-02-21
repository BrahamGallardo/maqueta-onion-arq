using Onion.Arq.Application.Models;

namespace Onion.Arq.Application.Interfaces.Services
{
    public interface IUserQueryService
    {
        Task<UserDto> GetByEmailAsync(string email);
    }
}
