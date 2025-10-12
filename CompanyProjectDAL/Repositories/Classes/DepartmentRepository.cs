
using CompanyProjectDAL.Data.Contects;
using CompanyProjectDAL.Repositories.Interfaces;

namespace CompanyProjectDAL.Repositories.Classes
{
    public class DepartmentRepository(CompanyDbContext dbContext) : IDepartmentRepository
    {
        private readonly CompanyDbContext _dbContext = dbContext;

        public IEnumerable<Department> GetAll(Func<Department, bool>? condition = null) => _dbContext.Departments.AsNoTracking().ToList();

        public Department? GetById(int id) => _dbContext.Departments.Find(id);
        public void Add(Department entity) => _dbContext.Departments.Add(entity);
        public void Update(Department entity) => _dbContext.Departments.Update(entity);
        public void Delete(Department entity) => _dbContext?.Departments.Remove(entity);

    }
}
