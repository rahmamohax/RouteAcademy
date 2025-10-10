using GymMangBLL.Services.Interfaces;
using GymMangDAL.Data.Contexts;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Classes;
using GymMangDAL.Repositories.Interfaces;

namespace GymMangBLL.Services.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly GymDbContext _dbContext;

        public ISessionRepository SessionRepository { get; }

        public UnitOfWork(GymDbContext dbContext, ISessionRepository sessionRepository)
        {
            _dbContext = dbContext;
            SessionRepository = sessionRepository;
        }

        public IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            var EntityType = typeof(TEntity);
            if (_repositories.TryGetValue(EntityType, out var repo))
                return (IEntityRepository<TEntity>) repo;

            var newRepo = new EntityRepository<TEntity>(_dbContext);
            _repositories[EntityType] = newRepo;
            return newRepo;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
