using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Models.Employees;
using Ikea.DAL.Persistence.Repository._Generic;

namespace Ikea.DAL.Persistence.Repository.Employees
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        //IEnumerable<Employee> GetAll(bool WithNoTracking = true);
        //Employee? GetById(int id);
        //int Add(Employee emp);
        //int Update(Employee emp);
        //int Delete(Employee emp);
        //IQueryable<Employee> GetAllAsQueryable();
    }
}
