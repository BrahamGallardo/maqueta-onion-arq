using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Arq.Application.Common.Specifications
{
    public abstract class BaseSpecification<E>: ISpecification<E>
    {
        public BaseSpecification()
        {
            Criteria = b => true;
        }

        public BaseSpecification(Expression<Func<E, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<E, bool>> Criteria { get; }
        public List<Expression<Func<E, object>>> Includes { get; } = new List<Expression<Func<E, object>>>();
        public Expression<Func<E, object>> OrderBy { get; protected set; }
        public Expression<Func<E, object>> OrderByDescending { get; protected set; }
        public List<string> IncludeStrings { get; } = new List<string>();

        public int PageSize { get; protected set; }
        public int PageNumber { get; protected set; }
        public bool IsPagingEnabled { get; protected set; } = false;
        public bool IgnoreQueryFilters { get; protected set; } = false;


        protected virtual void AddInclude(Expression<Func<E, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        // string-based includes allow for including children of children, e.g. Basket.Items.Product
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected void AddOrderBy(Expression<Func<E, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<E, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }
}
