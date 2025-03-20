using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ikea.BLL.Models.Employees;
using Ikea.BLL.Services.Common;
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

        public IAttachmentService _attachmentService { get; }

        public EmployeeService(/*IEmployeeRepository EmployeeRepo*/IUnitOfWork unitOfWork,IAttachmentService attachmentService)
        {
           // _EmployeeRepo = EmployeeRepo;
            this._unitOfWork = unitOfWork;
            _attachmentService = attachmentService;
        }
        public async Task<int> CreateEmployeeAsync(CreateEmployeeDTO Emp)
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
                //Image=Emp.Image,
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow
            };
            if (Emp.Image is not null)
            {
                employee.Image=await _attachmentService.UploadFileAsync(Emp.Image, "Files/Images");
            }
             _unitOfWork.employeeRepository.Add(employee);
            return await _unitOfWork.CompleteAsync();
               

        }

        public async Task<int> UpdateEmployeeAsync(UpdateEmployeeDTO Emp)
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
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var EmployeeRepo = _unitOfWork.employeeRepository;
            var employee= await EmployeeRepo.GetByIdAsync(id);
            if(employee is { })
            {
                employee.IsDeleted = true;
                 EmployeeRepo.Update(employee);
                //if (result > 0)
                    //return true;
            }
            
            return await _unitOfWork.CompleteAsync()>0;

        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(string Search)
        {
            return await _unitOfWork.employeeRepository.GetAllAsQueryable().Include(E => E.Department).Where(E=>string.IsNullOrEmpty(Search)||E.Name.ToLower().Contains(Search.ToLower())).Select(E => new EmployeeDTO()
            {
                Id=E.Id,
                Name=E.Name,
                Age=E.Age,
                IsActive=E.IsActive,
                Salary=E.Salary,
                Email=E.Email,
                gender = E.gender,
                empType = E.empType,
                Department=E.Department.Name,
                Image=E.Image
            }).ToListAsync();
        }

        public async Task<EmployeeDetailsDTO> GetEmployeeByIdAsync(int id)
        {
            var Emp=await _unitOfWork.employeeRepository.GetByIdAsync(id);
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
                    Image = Emp.Image,
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
