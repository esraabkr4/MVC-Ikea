using Ikea.BLL.Models.Departments;
using Ikea.BLL.Services.Departments;
using Ikea.PL.Models.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Ikea.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public ILogger _Logger { get; }
        public IWebHostEnvironment _environment { get; }
            
        #region Services
        public DepartmentController(IDepartmentService departmentService,ILogger<DepartmentController> logger,IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _Logger = logger;
           _environment = environment;
        }
        #endregion

        #region Index
        [HttpGet]
        //Baseurl/Department/Index
        public IActionResult Index()
        {

            var depts = _departmentService.GetAllDepartments();
            return View(depts);
        }
        #endregion

        #region Create
        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto NewDept)
        {
            if (!ModelState.IsValid)
                return View(NewDept);
            var message = string.Empty;
            try
                {
                    var result = _departmentService.CreateDepartment(NewDept);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                    message = "Error!! Department Not Created";
                    ModelState.AddModelError(string.Empty, message);

                    }
                return View(NewDept);
                }
                catch (Exception ex)
                {
                _Logger.LogError(ex,ex.Message);
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(NewDept);
                }
                else
                {
                    message = "Error!! Department Not Created";
                    return View("Error",message);
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

            var dept = _departmentService.GetDepartmentsById(id.Value);
            if (dept is null)
                return NotFound();

            return View(dept);
        }
        #endregion

        #region Update
        #region Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var dept = _departmentService.GetDepartmentsById(id.Value);
            if (dept is null)
                return NotFound();

            return View(new DepartmentEditVM()
            {
                Code=dept.Code,
                Name=dept.Name,
                Description=dept.Description,
                CreationDate=dept.CreationDate
            });
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Edit([FromRoute]int id, DepartmentEditVM DeptVM)
        {
            if (!ModelState.IsValid)
                return View(DeptVM);
            var message = string.Empty;
            try
            {
                var result = _departmentService.UpdateDepartment(new UpdateDepartmentDto()
                {
                    Id=id,
                    Code=DeptVM.Code,
                    Name=DeptVM.Name,
                    Description=DeptVM.Description,
                    CreationDate=DeptVM.CreationDate
                });
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Error!! Department Not Updated";
                    ModelState.AddModelError(string.Empty, message);

                }
                return View(DeptVM);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, ex.Message);
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(DeptVM);
                }
                else
                {
                    message = "Error!! Department Not Updated";
                    return View("Error", message);
                }



            }


        }
        #endregion

        #endregion
        #region Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            var result = _departmentService.DeleteDepartment(id.Value);
            if (!result)
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
