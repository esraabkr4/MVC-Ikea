using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Models.Employees;
using Ikea.DAL.Persistence.Data;
using Ikea.DAL.Persistence.Repository._Generic;

namespace Ikea.DAL.Persistence.Repository.Employees
{
    public class EmployeeRepository:GenericRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }

        
        //private readonly ApplicationDbContext dbContext;
        //public EmployeeRepository(ApplicationDbContext _dbContext)
        //{
        //    dbContext = _dbContext;
        //}

        //public IEnumerable<Employee> GetAll(bool WithNoTracking = true)
        //{
        //    if (WithNoTracking)
        //        return dbContext.Employees.AsNoTracking().ToList();
        //    return dbContext.Employees.ToList();


        //}

        //public Department? GetById(int id)
        //{
        //    var emp = dbContext.Employees.Find(id);
        //    return emp;
        //}
        //public int Add(Department emp)
        //{
        //    dbContext.Add(emp);
        //    return dbContext.SaveChanges();
        //}

        //public int Update(Department emp)
        //{
        //    dbContext.Update(emp);
        //    return dbContext.SaveChanges();
        //}

        //public int Delete(Department emp)
        //{
        //    dbContext.Remove(emp);
        //    return dbContext.SaveChanges();
        //}

        //public IQueryable<Department> GetAllAsQueryable()
        //{
        //    return dbContext.Departments;
        //}
    }
}
