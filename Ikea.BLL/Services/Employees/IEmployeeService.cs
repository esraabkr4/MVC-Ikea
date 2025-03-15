using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.BLL.Models.Departments;
using Ikea.BLL.Models.Employees;

namespace Ikea.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDetailsDTO? GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDTO Emp);
        int UpdateEmployee(UpdateEmployeeDTO Dept);
        bool DeleteEmployee(int id);
    }
}
