
using CompanyProjectDAL.Data.Contects;
using CompanyProjectDAL.Repositories.Interfaces;

namespace CompanyProjectDAL.Repositories.Classes
{
    public class DepartmentRepository(CompanyDbContext _dbContext) : IDepartmentRepository
    {
        public IEnumerable<Department> GetAll(Func<Department, bool>? condition = null) => _dbContext.Departments.AsNoTracking().ToList();

        public Department? GetById(int id) => _dbContext.Departments.Find(id);
        public bool Add(Department entity) {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(Department entity)
        {
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

    }
}
