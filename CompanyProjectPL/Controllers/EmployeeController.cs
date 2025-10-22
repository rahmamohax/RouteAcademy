using AutoMapper;
using CompanyProjectBLL.DTOs.DepartmentDtos;
using CompanyProjectBLL.DTOs.EmployeeDtos;
using CompanyProjectBLL.Services.Classes;
using CompanyProjectBLL.Services.Interfaces;
using CompanyProjectDAL.Models;
using CompanyProjectPL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyProjectPL.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService) : Controller
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
        public IActionResult Create(/*[FromServices] IDepartmentService _departmentService*/)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel createEmployee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreateEmployeeDto dto = new CreateEmployeeDto()
                    {
                        Name = createEmployee.Name,
                        DepartmentId = createEmployee.DepartmentId,
                        Address = createEmployee.Address,
                        Age = createEmployee.Age,
                        Email = createEmployee.Email,
                        EmployeeType = createEmployee.EmployeeType,
                        Gender = createEmployee.Gender,
                        HiringDate = createEmployee.HiringDate,
                        IsActive = createEmployee.IsActive,
                        PhoneNumber = createEmployee.PhoneNumber,
                        Salary = createEmployee.Salary
                    };

                    var res = _employeeService.AddEmployee(dto);
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

            //var mappedEmp = _mapper.Map<UpdateEmployeeDto>(employee);
            var mappedEmp = new EmployeeViewModel()
            {
                Email = employee.Email,
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                DepartmentId = employee.DepartmentId,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender),
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                HiringDate =DateOnly.FromDateTime(employee.HiringDate.Value) 
            };
            return View(mappedEmp);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UpdateEmployeeDto dto = new UpdateEmployeeDto()
            {
                Id = id,
                Name = model.Name,
                DepartmentId = model.DepartmentId,
                Address = model.Address,
                Age = model.Age,
                Email = model.Email,
                EmployeeType = model.EmployeeType,
                Gender = model.Gender,
                HiringDate = model.HiringDate,
                IsActive = model.IsActive,
                PhoneNumber = model.PhoneNumber,
                Salary = model.Salary
             };

            var result = _employeeService.UpdateEmployee(id, dto);

            if (result)
                return RedirectToAction(nameof(Index));
            return View(model);
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
