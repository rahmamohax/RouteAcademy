using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts
{
    public interface ISpecifications<TEntity, T> where TEntity : BaseEntity<T>
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
    }
}
