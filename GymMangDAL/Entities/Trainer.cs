using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Entities
{
    public enum Specialties
    {
        [Display(Name = "General Fitness")]
        GeneralFitness = 1,

        [Display(Name = "Yoga Trainer")]
        Yoga,

        [Display(Name = "Boxing Coach")]
        Boxing,

        [Display(Name = "CrossFit Instructor")]
        CrossFit
    }

    public class Trainer : GymUser
    {
        // HireDate == CreatedAt
        public Specialties Specialties { get; set; }

        public ICollection<Session> Sessions { get; set; } = null!; 
    }
}
