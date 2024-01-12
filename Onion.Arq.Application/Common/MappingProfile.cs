using AutoMapper;
using Onion.Arq.Application.Models;
using Onion.Arq.Domain.Entities;
using System.Reflection;

namespace Onion.Arq.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            CreateMap<User, UserDto>().ForPath(x => x.Role.Users, opt => opt.Ignore());
            CreateMap<UserDto, User>().ForPath(x => x.Role.Users, opt => opt.Ignore());

            CreateMap<Role, RoleDto>().ForMember(x => x.Users, opt => opt.Ignore());
            CreateMap<RoleDto, Role>().ForMember(x => x.Users, opt => opt.Ignore());

            CreateMap<Session, SessionDto>().ReverseMap();
        }
    }
}
