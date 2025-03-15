using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ikea.BLL.Models.Employees;
using Ikea.DAL.Common;
using Ikea.DAL.Models.Employees;
using Ikea.DAL.Persistence.Repository.Departments;
using Ikea.DAL.Persistence.Repository.Employees;

namespace Ikea.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _EmployeeRepo;

        public EmployeeService(IEmployeeRepository EmployeeRepo)
        {
            _EmployeeRepo = EmployeeRepo;
        }
        public int CreateEmployee(CreateEmployeeDTO Emp)
        {
            var employee = new Employee()
            {
                Name = Emp.Name,
                Age = Emp.Age,
                Address = Emp.Address,
                IsActive = Emp.IsActive,
                Salary = Emp.Salary,
                Email = Emp.Email,
                PhoneNumber = Emp.PhoneNumber,
                HiringDate = Emp.HiringDate,
                gender =  Emp.gender,
                empType = Emp.empType,
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow
            };
            var result = _EmployeeRepo.Add(employee);
            return result;
               

        }

        public int UpdateEmployee(UpdateEmployeeDTO Emp)
        {

            var employee = new Employee()
            {
                Id = Emp.Id,
                Name = Emp.Name,
                Age = Emp.Age,
                Address = Emp.Address,
                IsActive = Emp.IsActive,
                Salary = Emp.Salary,
                Email = Emp.Email,
                PhoneNumber = Emp.PhoneNumber,
                HiringDate = Emp.HiringDate,
                gender = Emp.gender,
                empType = Emp.empType,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow
            };
            var result = _EmployeeRepo.Update(employee);
            return result;
        }

        public bool DeleteEmployee(int id)
        {
            var employee=_EmployeeRepo.GetById(id);
            if(employee is { })
            {
                employee.IsDeleted = true;
                var result = _EmployeeRepo.Update(employee);
                if (result > 0)
                    return true;
            }
            
            return false;

        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _EmployeeRepo.GetAllAsQueryable().Select(E => new EmployeeDTO()
            {
                Id=E.Id,
                Name=E.Name,
                Age=E.Age,
                IsActive=E.IsActive,
                Salary=E.Salary,
                Email=E.Email,
                gender = E.gender,
                empType = E.empType
            });
        }

        public EmployeeDetailsDTO GetEmployeeById(int id)
        {
            var Emp= _EmployeeRepo.GetById(id);
            if(Emp is { })
            {

                return new EmployeeDetailsDTO()
                {
                    Id = Emp.Id,
                    Name = Emp.Name,
                    Age = Emp.Age,
                    Address = Emp.Address,
                    IsActive = Emp.IsActive,
                    Salary = Emp.Salary,
                    Email = Emp.Email,
                    PhoneNumber = Emp.PhoneNumber,
                    HiringDate = Emp.HiringDate,
                    gender = Emp.gender,
                    empType = Emp.empType,
                    CreatedBy = Emp.CreatedBy,
                    CreatedOn=Emp.CreatedOn,
                    LastModificationBy = Emp.LastModificationBy,
                    LastModificationOn = Emp.LastModificationOn
                };
            }
            return null;
        }

    }
}
