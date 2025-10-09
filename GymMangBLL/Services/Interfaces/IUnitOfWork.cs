using GymMangDAL.Entities;
using GymMangDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Interfaces
{
    public interface IUnitOfWork
    {
        //Applying The Single Atomic Transaction (Either all work or none)
        IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new();
        int SaveChanges();
    }
}
