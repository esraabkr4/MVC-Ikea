using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Persistence.Data;
using Ikea.DAL.Persistence.Repository.Departments;
using Ikea.DAL.Persistence.Repository.Employees;
using Microsoft.EntityFrameworkCore;

namespace Ikea.DAL.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository employeeRepository { get { return new EmployeeRepository(_dbContext); } }
        public IDepartmentRepository departmentRepository { get { return new DepartmentRepository(_dbContext); } }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            //employeeRepository=new EmployeeRepository(dbContext);
            //departmentRepository=new DepartmentRepository(dbContext);
            this._dbContext = dbContext;
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            _dbContext.DisposeAsync();
        }
    }
}
