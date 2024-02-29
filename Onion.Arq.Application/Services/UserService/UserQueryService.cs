using AutoMapper;
using Onion.Arq.Application.Common.Exceptions;
using Onion.Arq.Application.Interfaces.Repository;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Models;
using Onion.Arq.Application.Specifications.UserSpec;
using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Services.UserService
{
    public class UserQueryService(IMapper mapper, IRepositoryQueryAsync<User> repoQuery) : IUserQueryService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepositoryQueryAsync<User> _repoQuery = repoQuery;

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            try
            {
                List<User> users = await _repoQuery.ListAsync(new GetByEmailSpec(email));
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
