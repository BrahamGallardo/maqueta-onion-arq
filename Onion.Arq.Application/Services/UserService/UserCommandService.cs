using AutoMapper;
using Onion.Arq.Application.Interfaces.Repository;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Models;
using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Services.UserService
{
    public class UserCommandService(IMapper mapper, IRepositoryCommandAsync<User> repoCommand) : IUserCommandService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepositoryCommandAsync<User> _repoCommand = repoCommand;

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                user = await _repoCommand.CreateAsync(user);
                userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            catch (Exception e)
            {
                Exception ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }
    }
}
