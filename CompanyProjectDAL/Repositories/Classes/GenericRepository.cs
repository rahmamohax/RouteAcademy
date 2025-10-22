using CompanyProjectDAL.Data.Contects;
using CompanyProjectDAL.Repositories.Interfaces;

namespace CompanyProjectDAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(CompanyDbContext _dbContext) : IGenericRepository<TEntity>  where TEntity : BaseEntity, new()
    {
        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
            if (condition == null)
                return _dbContext.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == false).ToList();
            return _dbContext.Set<TEntity>().AsNoTracking()
                .Where(condition)
                .Where(x => x.IsDeleted == false)
                .ToList();
        }

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);
        public void Add(TEntity entity) {
            _dbContext.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

    }
}
