using Onion.Arq.Application.Specifications;
using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Specifications.UserSpec
{
    public class GetByEmailSpec : BaseSpecification<User>
    {
        public GetByEmailSpec(string email) : base(x => x.Email == email) { }
    }
}
