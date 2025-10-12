using Microsoft.AspNetCore.Mvc;
using Project01.Models;

namespace Project01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); //return with same name (index)
            //return View("HomePage"); //return with spcific name
            //return View("HomePage", new Movie()); //return with spcific name and model(data)
        }
        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}
