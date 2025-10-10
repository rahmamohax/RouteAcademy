using GymMangDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Repositories.Interfaces
{
    public interface ISessionRepository : IEntityRepository<Session>
    {
        IEnumerable<Session> GetAllSessionsWithRelations();
        int coutOfBookedSlots(int sessionId);

        Session? GetSessionWithRelations(int sessionId);
    }
}
