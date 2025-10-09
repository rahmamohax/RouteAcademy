using GymMangBLL.ViewModels.PlanViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Interfaces
{
    public interface IPlanService
    {
        IEnumerable<PlanViewModel> GetAllPlans();
        PlanViewModel? GetPlanById(int id);
        UpdatePlanViewModel? GetUpdatePlan(int Id);
        bool UpdatePlan(int Id,PlanViewModel planToUpdate);
        bool ToggleStatus(int Id);
    }
}
