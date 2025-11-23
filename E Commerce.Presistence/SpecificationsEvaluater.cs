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
            ISpecifications<TEntity, T> includes) where TEntity : BaseEntity<T>
        {
            var query = entryPoint; //_dbContext.Products;
            if(includes is not null)
            {
                if(includes.IncludeExpressions is not null && includes.IncludeExpressions.Any())
                {
                    //foreach (var item in includes.IncludeExpressions)
                    //{
                    //    query = query.Include(item);
                    //}
                    query = includes.IncludeExpressions.Aggregate(query,
                        (currentQuery, includeExp) => currentQuery.Include(includeExp));
                    //_dbContext.Products
                    // p => p.ProductType
                    //_dbContext.Products.include(p => p.ProductType)  <=  currentQuery
                    // p => p.ProductBrand

                }
            }
            return query;
        }
    }
}
