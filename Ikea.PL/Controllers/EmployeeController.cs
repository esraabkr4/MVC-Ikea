﻿using AspNetCoreGeneratedDocument;
using AutoMapper;
using Ikea.BLL.Models.Employees;
using Ikea.BLL.Services.Departments;
using Ikea.BLL.Services.Employees;
using Ikea.DAL.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Ikea.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public ILogger _Logger { get; }
        public IWebHostEnvironment _environment { get; }

        #region Services
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, ILogger<EmployeeController> logger, IWebHostEnvironment environment,IMapper mapper)
        {
            _employeeService = employeeService;
            this._departmentService = departmentService;
            _Logger = logger;
            _environment = environment;
            this._mapper = mapper;
        }
        #endregion

        #region Index
        [HttpGet]
        //Baseurl/Employee/Index
        public IActionResult Index(string Search)
        {

            var emps = _employeeService.GetEmployees(Search);
            //if(Request.IsAjaxRequest())
            //    return PartialView(nameof(EmployeeListPartial),emps);
            return View(emps);
        }
        #endregion

        #region Create
        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Departments"] = _departmentService.GetAllDepartments();
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UpdateEmployeeDTO EmpVM)
        {
            if (!ModelState.IsValid)
                return View(EmpVM);
            var message = string.Empty;
            try
            {
                var NewEmp=_mapper.Map<CreateEmployeeDTO>(EmpVM);
                var result = _employeeService.CreateEmployee(NewEmp);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Error!! Employee Not Created";
                    ModelState.AddModelError(string.Empty, message);

                }
                return View(NewEmp);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(EmpVM);
                }
                else
                {
                    message = "Error!! Employee Not Created";
                    return View("Error", message);
                }



            }


        }
        #endregion
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var emp = _employeeService.GetEmployeeById(id.Value);
            if (emp is null)
                return NotFound();

            return View(emp);
        }
        #endregion

        #region Update
        #region Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var emp = _employeeService.GetEmployeeById(id.Value);
            if (emp is null)
                return NotFound();

            ViewData["Departments"] = _departmentService.GetAllDepartments();
            var UpdatedEmployee=_mapper.Map<EmployeeDetailsDTO,UpdateEmployeeDTO>(emp);
            return View(UpdatedEmployee);
            //Manual Mapper
            //return View(new UpdateEmployeeDTO()
            //{
            //    Name = emp.Name,
            //    Address = emp.Address,
            //    Email = emp.Email,
            //    Age=emp.Age,
            //    Salary=emp.Salary,
            //    PhoneNumber=emp.PhoneNumber,
            //    IsActive=emp.IsActive,
            //    HiringDate=emp.HiringDate,
            //    gender=emp.gender,
            //    empType=emp.empType

            //});
        }
        #endregion
        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, UpdateEmployeeDTO empDto)
        {
            if (!ModelState.IsValid)
                return View(empDto);
            var message = string.Empty;
            try
            {
                empDto.Id = id;
                var result = _employeeService.UpdateEmployee(empDto);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Error!! Employee Not Updated";
                    ModelState.AddModelError(string.Empty, message);

                }
                return View(empDto);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(empDto);
                }
                else
                {
                    message = "Error!! Employee Not Updated";
                    return View("Error", message);
                }



            }

        }
        #endregion

        #endregion
        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var result = _employeeService.DeleteEmployee(id.Value);
            if (!result)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
