using GymMangDAL.Data.Contexts;
using GymMangDAL.Entities;
using GymMangDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Repositories.Classes
{
    internal class SessionRepository : EntityRepository<Session>, ISessionRepository
    {
        public SessionRepository(GymDbContext dbContext) : base(dbContext)
        {
        }
    }
}
