using Ardalis.Specification;
using Onion.Arq.Domain.Entities;

namespace Onion.Arq.Application.Common.Specifications.UserSpec
{
    public class GetByEmailSpecification : Specification<User>
    {
        public GetByEmailSpecification(string email)
        {
            Query.Where(e => e.Email.Equals(email));
            Query.Include(e => e.Role);
        }
    }
}
