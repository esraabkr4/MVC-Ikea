using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;

namespace Ikea.DAL.Persistence.Repository.Departments
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool WithNoTracking = true);
        Department? GetById(int id);
        int Add(Department dept);
        int Update(Department dept);
        int Delete(Department dept);
        IQueryable<Department> GetAllAsQueryable();
    }
}
