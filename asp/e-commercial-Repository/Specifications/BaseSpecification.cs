using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Repository.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> creteria)
        {
            Creteria = creteria;
        }
        public BaseSpecification()
        {

        }

        public Expression<Func<T, bool>> Creteria { get; }

        public List<Expression<Func<T, object>>> Includs { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAscending { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get;private set; }

        public int Skip { get; private set; }

        public bool IsPaginEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includs.Add(include);
        }
        protected void AddOrderByAsc(Expression<Func<T, object>> orderByAsc)
        {
            OrderByAscending = orderByAsc;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDesc)
        {
            OrderByDescending = orderByDesc;
        }
        protected void ApplyPagination(int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPaginEnabled = true;
        }

    }
}
