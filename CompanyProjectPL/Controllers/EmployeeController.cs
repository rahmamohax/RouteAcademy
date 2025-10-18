using AutoMapper;
using CompanyProjectBLL.DTOs.DepartmentDtos;
using CompanyProjectBLL.DTOs.EmployeeDtos;
using CompanyProjectBLL.Services.Classes;
using CompanyProjectBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectPL.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService, IMapper _mapper) : Controller
    {
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if(employee is null) return NotFound();
            return View(employee);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto createEmployee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = _employeeService.AddEmployee(createEmployee);
                    return (res) ? RedirectToAction(nameof(Index)) : View(createEmployee);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else return View(createEmployee);
        }

        #endregion

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if(employee is null) return NotFound();

            var mappedEmp = _mapper.Map<UpdateEmployeeDto>(employee);
            //var mappedEmp = new UpdateEmployeeDto()
            //{
            //    Id = employee.Id,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //};
            return View(mappedEmp);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, UpdateEmployeeDto updateEmployee)
        {
            if (!ModelState.IsValid)
                return View(updateEmployee);

            var result = _employeeService.UpdateEmployee(id, updateEmployee);

            if (result)
                return RedirectToAction(nameof(Index));
            return View(updateEmployee);
        }

        #region Delete
        public ActionResult Delete([FromRoute] int id)
        {
            var res = _employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
