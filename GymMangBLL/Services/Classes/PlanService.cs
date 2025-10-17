using AutoMapper;
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
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            return _mapper.Map<IEnumerable<PlanViewModel>>(plans);
        }

        public PlanViewModel? GetPlanById(int id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(id);
            if (plan is null) return null;
            return _mapper.Map<PlanViewModel>(plan);
        }

        public UpdatePlanViewModel? GetUpdatePlan(int Id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(Id);
            if (plan is null || plan.IsActive == false || hasActiveMembership(Id)) return null;  //Cant update plans with active membership
            return _mapper.Map<UpdatePlanViewModel>(plan);
        }
        public bool UpdatePlan(int Id, UpdatePlanViewModel planToUpdate)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(Id);
            if (plan is null) return false;
            try
            {
               _mapper.Map(planToUpdate, plan);

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
