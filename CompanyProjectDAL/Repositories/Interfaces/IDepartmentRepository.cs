

namespace CompanyProjectDAL.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Department? GetById(int id);
        IEnumerable<Department> GetAll(Func<Department, bool>? condition = null);
        bool Add(Department entity);
        bool Update(Department entity);
        bool Delete(Department entity);
    }
}
