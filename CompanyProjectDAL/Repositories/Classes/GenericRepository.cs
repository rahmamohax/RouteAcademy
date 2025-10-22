
using CompanyProjectDAL.Data.Contects;
using CompanyProjectDAL.Repositories.Interfaces;

namespace CompanyProjectDAL.Repositories.Classes
{
    public class GenericRepository<TEntity>(CompanyDbContext _dbContext) : IGenericRepository<TEntity>  where TEntity : BaseEntity, new()
    {
        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
            => _dbContext.Set<TEntity>().AsNoTracking().Where(x => x.IsDeleted == false).ToList();

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);
        public bool Add(TEntity entity) {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

    }
}
