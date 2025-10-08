using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Repositories.Interfaces
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        //Get All
        IEnumerable<TEntity> GetAll();

        //Get By Id
        TEntity? GetById(int id);

        //Add
        int Add(TEntity entity);

        //Update
        int Update(TEntity entity);

        //Delete
        int Delete(int Id);
    }
}
