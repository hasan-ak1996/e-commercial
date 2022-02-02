using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Repository.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Creteria { get; }
        List<Expression<Func<T,object>>> Includs { get; }
    }
}
