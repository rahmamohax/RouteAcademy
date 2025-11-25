using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using System.Linq.Expressions;

namespace E_Commerce.Services.Specifications
{
    public abstract class BaseSpecification<TEntity, T> : ISpecifications<TEntity, T> where TEntity : BaseEntity<T>
    {
        #region Criteria
        public Expression<Func<TEntity, bool>> Criteria { get; }

        protected BaseSpecification(Expression<Func<TEntity, bool>> expression)
        {
            Criteria = expression;
        }
        #endregion

        #region Includes
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
        protected void AddInclude(Expression<Func<TEntity, object>> includeExp)
        {
            IncludeExpressions.Add(includeExp);
        }
        #endregion

        #region Order By
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
        {
            OrderBy = orderByDescExpression;
        }
        #endregion

        public int Skip { get; private set; }

        public int Take { get; private set; }
        public bool IsPaginated { get; private set; }

        protected void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
    }
}
