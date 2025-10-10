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
    public class SessionRepository : EntityRepository<Session>, ISessionRepository
    {
        private readonly GymDbContext _dbContext;

        public SessionRepository(GymDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public int coutOfBookedSlots(int sessionId)
        {
            
            return _dbContext.MemberSessions.Count(s => s.SessionId == sessionId);
        }

        public IEnumerable<Session> GetAllSessionsWithRelations()
        {
            return _dbContext.Sessions.Include(x => x.Trainer)
                                    .Include(x => x.Category)
                                    .ToList();
        }

        public Session? GetSessionWithRelations(int sessionId)
        {
            return _dbContext.Sessions.Include(x => x.Trainer)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == sessionId);
        }
    }
}
