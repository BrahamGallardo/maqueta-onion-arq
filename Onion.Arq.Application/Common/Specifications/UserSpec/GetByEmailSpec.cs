using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Common.Specifications.UserSpec
{
    public class GetByEmailSpec : BaseSpecification<User>
    {
        public GetByEmailSpec(string email) : base(x => x.Email == email) { }
    }
}
