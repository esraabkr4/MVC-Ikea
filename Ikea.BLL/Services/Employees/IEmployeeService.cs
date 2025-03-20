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
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(string Search);
        Task<EmployeeDetailsDTO?> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(CreateEmployeeDTO Emp);
        Task<int> UpdateEmployeeAsync(UpdateEmployeeDTO Dept);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
