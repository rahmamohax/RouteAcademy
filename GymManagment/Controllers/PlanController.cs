using GymMangBLL.Services.Classes;
using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.PlanViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }
        public IActionResult Index()
        {
            var plans = _planService.GetAllPlans();
            return View(plans);
        }
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var plan = _planService.GetPlanById(id);
            if (plan is null)
            {
                TempData["ErrorMessage"] = "Plan Not Found";
                return RedirectToAction(nameof(Index));
            }

            return View(plan);
        }

        #region Edit Plan
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var planView = _planService.GetUpdatePlan(id);
            if (planView is null)
            {
                TempData["ErrorMessage"] = "Cant Edit InActive Plans or Plans with Active Membership";
                return RedirectToAction(nameof(Index));
            }

            return View(planView);
        }

        [HttpPost]
        public ActionResult Edit([FromForm] int id, UpdatePlanViewModel updatePlan)
        {
            if(!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Make Sure you filled all Fields";
                return View(updatePlan);
            }
            var plan = _planService.UpdatePlan(id, updatePlan);
            if (plan)
                TempData["SuccessMessage"] = "Plan Updated Successfully";
            
            else
                TempData["ErrorMessage"] = "Failed to Update Plan";
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Activation( int id)
        {
            var status = _planService.ToggleStatus(id);
            if (status)
               TempData["SuccessMessage"] = "Updated Status Successfully";
            else
               TempData["ErrorMessage"] = "Can't Deactivate Plans with Active Memberships";


            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}
