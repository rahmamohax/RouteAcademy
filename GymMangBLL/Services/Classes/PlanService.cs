using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.PlanViewModels;
using GymMangDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangBLL.Services.Classes
{
    internal class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Helper
        private bool hasActiveMembership(int planId)
        {
            var active = _unitOfWork.GetRepository<MemberShip>().GetAll(x => x.PlanId == planId && x.Status == "Active").Any();
            return active;
        }
        #endregion
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var plans = _unitOfWork.GetRepository<Plan>().GetAll();
            if (plans is null || !plans.Any()) return [];
            return plans.Select(p => new PlanViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DurationDays = p.DurationDays,
                Price = p.Price,
                IsActive = p.IsActive,
            });
        }

        public PlanViewModel? GetPlanById(int id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(id);
            if (plan is null) return null;
            return new PlanViewModel
            {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
                IsActive = plan.IsActive,
            };
        }

        public UpdatePlanViewModel? GetUpdatePlan(int Id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(Id);
            if (plan is null || plan.IsActive == false || hasActiveMembership(Id)) return null;  //Cant update plans with active membership
            return new UpdatePlanViewModel
            {
                Name = plan.Name,
                Description = plan.Description,
                Duration = plan.DurationDays,
                Price = plan.Price
            };
        }
        public bool UpdatePlan(int Id, PlanViewModel planToUpdate)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(Id);
            if (plan is null) return false;
            try
            {
                (plan.Description, plan.DurationDays, plan.Price, plan.UpdatedAt) = (planToUpdate.Description, planToUpdate.DurationDays, planToUpdate.Price, DateTime.Now);

                _unitOfWork.GetRepository<Plan>().Update(plan);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //SoftDelete
        public bool ToggleStatus(int Id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(Id);
            if (plan is null || hasActiveMembership(Id)) return false;

            plan.IsActive = !plan.IsActive;
            plan.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.GetRepository<Plan>().Update(plan);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
