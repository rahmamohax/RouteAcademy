using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities;
using E_Commerce.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presistence.Repositories
{
    public class GenericRepository<TEntity, T> : IGenericRepository<TEntity, T> where TEntity : BaseEntity<T>
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(T id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, T> specifications)
        {
            IQueryable<TEntity> query = SpecificationsEvaluater.CreateQuery(_dbContext.Set<TEntity>(), specifications);
            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, T> specifications)
        {
            return await SpecificationsEvaluater.CreateQuery(_dbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecifications<TEntity, T> specifications)
        {
            return await SpecificationsEvaluater.CreateQuery(_dbContext.Set<TEntity>(), specifications).CountAsync(); 
        }
    }
}
