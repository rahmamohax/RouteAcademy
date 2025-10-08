using GymMangDAL.Data.Contexts;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _dbContext;

        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Plan> GetAll() => _dbContext.Set<Plan>().AsNoTracking().ToList();

        public Plan? GetById(int id) => _dbContext.Set<Plan>().Find(id);

        public int Update(Plan entity)
        {
            _dbContext.Set<Plan>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
