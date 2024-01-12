using AutoMapper;
using Onion.Arq.Application.Common.Exceptions;
using Onion.Arq.Application.Common.Specifications.UserSpec;
using Onion.Arq.Application.Interfaces;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Models;
using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Services.UserService
{
    public class UserAsyncService : IUserAsyncService
    {
        private readonly IRepositoryAsyncArdalis<User> _repo;
        private readonly IMapper _mapper;

        public UserAsyncService(IRepositoryAsyncArdalis<User> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            try
            {
                List<User> users = await _repo.ListAsync(new GetByEmailSpecification(email));
                if (users.FirstOrDefault() == null)
                {
                    throw new NotFoundException("User", email);
                }
                UserDto userDto = _mapper.Map<UserDto>(users.FirstOrDefault());
                return userDto;
            }
            catch (Exception e)
            {
                var ex = e.InnerException ?? new Exception(e.Message);
                throw ex;
            }
        }
    }
}
