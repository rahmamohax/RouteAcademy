using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetTrainers()
        {
            return View();
        }
        public ActionResult CreateTrainer()
        {
            return View();
        }
    }
}
