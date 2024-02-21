using Onion.Arq.Application.Models;

namespace Onion.Arq.Application.Interfaces.Services
{
    public interface IUserCommandService
    {
        Task<UserDto> CreateUserAsync(UserDto userDto);
    }
}
