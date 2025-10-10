using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Index(int id)
        {
            //return View();
            //return Redirect(nameof(GetMembers));
            return RedirectToRoute("Trainer", new {action = "GetTrainers"}); //name of rout

        }

        public ActionResult GetMembers()
        {
            return View();
        }
        public ActionResult CreateMember()
        {
            return View();
        }
    }
}
