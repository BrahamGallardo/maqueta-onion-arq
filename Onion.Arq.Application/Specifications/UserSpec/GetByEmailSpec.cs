using Onion.Arq.Application.Specifications;
using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Specifications.UserSpec
{
    public class GetByEmailSpec(string email) : BaseSpecification<User>(x => x.Email == email)
    {
    }
}
