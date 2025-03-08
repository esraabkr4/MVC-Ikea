using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Persistence.Repository._Generic;

namespace Ikea.DAL.Persistence.Repository.Departments
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
        IEnumerable<Department> GetSpecificDepartment();
        //IEnumerable<Department> GetAll(bool WithNoTracking = true);
        //Department? GetById(int id);
        //int Add(Department dept);
        //int Update(Department dept);
        //int Delete(Department dept);
        //IQueryable<Department> GetAllAsQueryable();
    }
}
