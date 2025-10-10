using GymMangBLL.Services.Interfaces;
using GymMangDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnalyticsService _analyticsService;

        public HomeController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        //Url/Controller/Action
        //BaseUrl/Home/Index
        //[NonAction] //method will not be invoked
        public ViewResult Index()
        {
            var data = _analyticsService.GetAnalytics();
            return View(data);
        }
        public JsonResult Trainers()
        {
            var trainers= new List<Trainer>()
            {
                new Trainer(){Name = "Ali", Phone="123456"},
                new Trainer(){Name= "Amr", Phone="0123494"}
            };
            return Json(trainers);
        }
        public RedirectResult Redirect()
        {
            return Redirect("https://github.com/AliaaAbdelhamid");
        }

        public ContentResult Content()
        {
            return Content("Hello world");
        }

        public FileResult DownloadFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/site.css");
            var data = System.IO.File.ReadAllBytes(path);
            return File(data, "text/css", "NewFile");
        }

        public EmptyResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
