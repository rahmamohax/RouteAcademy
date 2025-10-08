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
    public class MemberRepository : EntityRepository<Member>, IMemberRepository
    {

        //Asking CLR to inject object
        public MemberRepository(GymDbContext dbContext) : base(dbContext)
        {
        }

    }
}
