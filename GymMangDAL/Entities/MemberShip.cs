using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Entities
{
    public class MemberShip : BaseEntity
    {
        // StartDate == CreatedAt
        public DateTime EndDate { get; set; }

        //ReadOnly Property
        public string Status
        {
            get
            {
                if (EndDate >= DateTime.Now) return "Expired";
                else return "Active";
            }
        }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;
    }
}
