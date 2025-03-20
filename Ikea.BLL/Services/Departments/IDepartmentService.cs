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
        Task< IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task< DepartmentDetailsDto> GetDepartmentsByIdAsync(int id);
        Task< int> CreateDepartmentAsync(CreateDepartmentDto Dept);
        Task<int> UpdateDepartmentAsync(UpdateDepartmentDto Dept);
        Task<bool> DeleteDepartmentAsync(int id);


    }
}
