using e_commercial_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Repository.Specifications
{
    public class SpicificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(
            IQueryable<TEntity> queryInput,
            ISpecification<TEntity> spec
            )
        {
            IQueryable<TEntity> query = queryInput;
            if(spec.Creteria != null)
            {
                query = query.Where(spec.Creteria);
            }
            if(spec.OrderByAscending != null)
            {
                query = query.OrderBy(spec.OrderByAscending);
            }
            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }
            if (spec.IsPaginEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            query = spec.Includs.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
