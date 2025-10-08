using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Entities
{
    public enum Specialties
    {
        GeneralFitness =1,
        Yoga,
        Boxing,
        Crossfit
    }
    public class Trainer : GymUser
    {
        // HireDate == CreatedAt
        public Specialties Specialties { get; set; }

        public ICollection<Session> Sessions { get; set; } = null!; 
    }
}
