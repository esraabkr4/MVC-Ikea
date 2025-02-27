using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Ikea.DAL.Persistence.Repository.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;
        public DepartmentRepository(ApplicationDbContext _dbContext)
        {
            dbContext= _dbContext;
        }

        public IEnumerable<Department> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return dbContext.Departments.AsNoTracking().ToList();
            return dbContext.Departments.ToList();


        }

        public Department? GetById(int id)
        {
            var dept = dbContext.Departments.Find(id);
            return dept;
        }
        public int Add(Department dept)
        {
            dbContext.Add(dept);
            return dbContext.SaveChanges();
        }

        public int Update(Department dept)
        {
            dbContext.Update(dept);
            return dbContext.SaveChanges();
        }

        public int Delete(Department dept)
        {
            dbContext.Remove(dept);
            return dbContext.SaveChanges();
        }

        public IQueryable<Department> GetAllAsQueryable()
        {
            return dbContext.Departments;
        }
    }
}
