using GymManagementSystemBLL.ViewModels.SessionViewModels;
using GymMangBLL.Services.Classes;
using GymMangBLL.Services.Interfaces;
using GymMangBLL.ViewModels.SessionViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagment.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public IActionResult Index()
        {
            var sessions = _sessionService.GetAllSessions();
            return View(sessions);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var session = _sessionService.GetSessionById(id);
            if (session is null)
            {
                TempData["ErrorMessage"] = "Session Not Found";
                return RedirectToAction(nameof(Index));
            }

            return View(session);
        }

        #region Create Session
        public IActionResult Create()
        {
            LoadDropDownCategories();
            LoadDropDownTrainers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSessionViewModel createSession)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidData", "Check Validation and Missing Fields");
                LoadDropDownCategories();
                LoadDropDownTrainers();
                return View(nameof(Create), createSession);
            }
            var result = _sessionService.CreateSession(createSession);
            if (result)
            {
                TempData["SuccessMessage"] = "Session Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Creation Has Failed";
                LoadDropDownCategories();
                LoadDropDownTrainers();
                return View(createSession);
            }
        }
        #endregion

        #region Edit Session
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }

            var session = _sessionService.GetSessionToUpdate(id);
            if (session is null)
            {
                TempData["ErrorMessage"] = "Session Can't be Updated";
                return RedirectToAction(nameof(Index));
            }
            LoadDropDownTrainers();
            return View(session);

        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdateSessionViewModel updateSession)
        {
            if (!ModelState.IsValid) {
                LoadDropDownTrainers();
                return View(updateSession);
            }

            var result = _sessionService.UpdateSession(id, updateSession);
            if (result)
            {
                TempData["SuccessMessage"] = "Session Updated Successfully";
                //return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Update Has Failed";
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Id can't be 0 or negative";
                return RedirectToAction(nameof(Index));
            }
            var session = _sessionService.GetSessionById(id);
            if (session is null)
            {
                TempData["ErrorMessage"] = "Session Not Found";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SessionId = session.Id;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _sessionService.DeleteSession(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Session Deleted Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Session Can't be Deleted";
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Helper Methods
        private void LoadDropDownCategories()
        {
            var categories = _sessionService.GetCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
        private void LoadDropDownTrainers()
        {
            var trainers = _sessionService.GetTrainers();
            ViewBag.Trainers = new SelectList(trainers, "Id", "Name");
        }
        #endregion
    }
}
