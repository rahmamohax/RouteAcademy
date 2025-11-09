using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.TrainerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            this._trainerService = trainerService;
        }

        public IActionResult Index(int id)
        {
            var trainers = _trainerService.GetAllTrainers();
            return View(trainers);

        }

        public IActionResult TrainerDetails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var trainer = _trainerService.GetTrainerDetails(id);
            if (trainer is null)
            {
                TempData["ErrorMessage"] = "Trainer Not Found";
                return RedirectToAction(nameof(Index));
            }

            return View(trainer);
        }


        #region Create trainer
        //get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrainer(CreateTrainerViewModel createTrainer)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidData", "Check Validation and Missing Fields");
                return View(nameof(Create), createTrainer);
            }
            var result = _trainerService.CreateTrainer(createTrainer);
            if (result)
            {
                TempData["SuccessMessage"] = "Trainer Created Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Creation Has Failed, Check Phone and Email";
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit trainer
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var trainer = _trainerService.TrainerToUpdate(id);
            if (trainer is null)
            {
                TempData["ErrorMessage"] = "trainer Not Found";
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdateTrainerViewModel updatetrainer)
        {
            if (!ModelState.IsValid)
            {
                return View(updatetrainer);
            }
            var result = _trainerService.UpdateTrainerDetails(id, updatetrainer);
            if (result)
            {
                TempData["SuccessMessage"] = "Trainer Updated Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Update Has Failed, Check Phone and Email";
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete trainer
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var trainer = _trainerService.GetTrainerDetails(id);
            if (trainer is null)
            {
                TempData["ErrorMessage"] = "trainer Not Found";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.TrainerId = id;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed([FromForm] int id)
        {
            var delete = _trainerService.DeleteTrainer(id);
            if (delete)
                TempData["SuccessMessage"] = "Trainer is Deleted Successfully";
            else
                TempData["ErrorMessage"] = "Failed to Delete Trainer";
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }

}
