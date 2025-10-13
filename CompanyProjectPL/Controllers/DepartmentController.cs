using CompanyProjectBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectPL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService) : Controller
    {
        //Url/Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }
    }
}
