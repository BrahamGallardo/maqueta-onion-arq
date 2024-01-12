using Onion.Arq.Application.Models;

namespace Onion.Arq.Application.Interfaces.Services
{
    public interface IUserAsyncService
    {
        Task<UserDto> GetByEmailAsync(string email);
    }
}
