using Ikea.BLL.Services.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Ikea.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        [HttpGet]
        //Baseurl/Department/Index
        public IActionResult Index()
        {
            var depts = _departmentService.GetAllDepartments();
            return View(depts);
        }
    }
}
