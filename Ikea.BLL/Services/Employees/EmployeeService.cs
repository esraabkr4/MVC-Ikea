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
using Ikea.DAL.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Ikea.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        //public IEmployeeRepository _EmployeeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(/*IEmployeeRepository EmployeeRepo*/IUnitOfWork unitOfWork)
        {
           // _EmployeeRepo = EmployeeRepo;
            this._unitOfWork = unitOfWork;
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
                DepartmentId=Emp.DepartmentId,
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow
            };
             _unitOfWork.employeeRepository.Add(employee);
            return _unitOfWork.Complete();
               

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
                DepartmentId = Emp.DepartmentId,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow
            };
             _unitOfWork.employeeRepository.Update(employee);
            return _unitOfWork.Complete();
        }

        public bool DeleteEmployee(int id)
        {
            var EmployeeRepo = _unitOfWork.employeeRepository;
            var employee=EmployeeRepo.GetById(id);
            if(employee is { })
            {
                employee.IsDeleted = true;
                 EmployeeRepo.Update(employee);
                //if (result > 0)
                    //return true;
            }
            
            return _unitOfWork.Complete()>0;

        }

        public IEnumerable<EmployeeDTO> GetEmployees(string Search)
        {
            return _unitOfWork.employeeRepository.GetAllAsQueryable().Include(E => E.Department).Where(E=>string.IsNullOrEmpty(Search)||E.Name.ToLower().Contains(Search.ToLower())).Select(E => new EmployeeDTO()
            {
                Id=E.Id,
                Name=E.Name,
                Age=E.Age,
                IsActive=E.IsActive,
                Salary=E.Salary,
                Email=E.Email,
                gender = E.gender,
                empType = E.empType,
                Department=E.Department.Name
            }).ToList();
        }

        public EmployeeDetailsDTO GetEmployeeById(int id)
        {
            var Emp= _unitOfWork.employeeRepository.GetById(id);
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
                    Department = Emp.Department?.Name,
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
