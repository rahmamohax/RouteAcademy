using CompanyProjectBLL.DTOs.DepartmentDtos;
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

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto createDepartment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res =_departmentService.AddDepartment(createDepartment);
                    return (res) ? RedirectToAction(nameof(Index)) : View(createDepartment);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else return View(createDepartment);
        }

        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit
        public ActionResult Edit(int? id)
        {
            if(!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value); // must map to updateViewModel
            if (department is null) return NotFound();

            var ViewModel = new UpdateDepartmentDto()
            {
                Id= id.Value,
                Name = department.Name,
                Code= department.Code,
                Description= department.Description,
                CreatedAt = DateTime.Now
            };


            return View(ViewModel);
        }

        [HttpPost]
        public ActionResult Edit([FromRoute] int id, UpdateDepartmentDto updateDepartment)
        {
            if (!ModelState.IsValid)
                return View(updateDepartment);

            var result = _departmentService.UpdateDepartment(id, updateDepartment);

            if(result)
                return RedirectToAction(nameof(Index)); 
            return View(updateDepartment);
        }
        #endregion

        #region Delete
        public ActionResult Delete([FromRoute]int id)
        {
            var res = _departmentService.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
