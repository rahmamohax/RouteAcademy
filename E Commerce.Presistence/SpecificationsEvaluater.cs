using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presistence
{
    internal static class SpecificationsEvaluater
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, T>(IQueryable<TEntity> entryPoint,
            ISpecifications<TEntity, T> specifications) where TEntity : BaseEntity<T>
        {
            var query = entryPoint; //_dbContext.Products;
            if(specifications is not null)
            {
                if (specifications.Criteria is not null)
                {
                    query = query.Where(specifications.Criteria);
                }

                if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Any())
                {                
                    query = specifications.IncludeExpressions.Aggregate(query,
                        (currentQuery, includeExp) => currentQuery.Include(includeExp));
                    //_dbContext.Products
                    // p => p.ProductType
                    //_dbContext.Products.include(p => p.ProductType)  <=  currentQuery
                    // p => p.ProductBrand
                }
                
                if(specifications.OrderBy is not null)
                    query = query.OrderBy(specifications.OrderBy);

                if(specifications.OrderByDescending is not null)
                    query = query.OrderByDescending(specifications.OrderByDescending);

                if(specifications.IsPaginated)
                    query = query.Skip(specifications.Skip).Take(specifications.Take);
            }
            return query;
        }
    }
}
