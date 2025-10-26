using GymMangDAL.Data.Contexts;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GymMangDAL.Repositories.Classes
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly GymDbContext _dbContext;

        //Asking CLR to inject object
        public EntityRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);

        public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
            if (condition is null) 
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            else
                return _dbContext.Set<TEntity>().AsNoTracking().Where(condition).ToList();

        }

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

        public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
    }
}
