using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.BLL.Models.Departments;
using Ikea.DAL.Models.Departments;

namespace Ikea.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto GetDepartmentsById(int id);
        int CreateDepartment(CreateDepartmentDto Dept);
        int UpdateDepartment(UpdateDepartmentDto Dept);
        bool DeleteDepartment(int id);


    }
}
