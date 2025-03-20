using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.BLL.Models.Departments;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Persistence.Repository.Departments;
using Ikea.DAL.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Ikea.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        //public IDepartmentRepository _unitOfWork.departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
     

        public DepartmentService(/*IDepartmentRepository _departmentRepo*/IUnitOfWork unitOfWork)
        {
            //DepartmentRepo = __unitOfWork.departmentRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task< IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            //var Departments = _unitOfWork.departmentRepository.GetAll();
            //foreach (var dept in Departments)
            //{
            //    //manual mapping
            //    yield return new DepartmentDto()
            //    {
            //        Id = dept.Id,
            //        Name = dept.Name,
            //        Description = dept.Description,
            //        Code = dept.Code,
            //        CreationDate = dept.CreationDate
            //    };
            //}
            var Departments =await _unitOfWork.departmentRepository.GetAllAsQueryable().Select(dept => new DepartmentDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Description = dept.Description,
                Code = dept.Code,
                CreationDate = dept.CreationDate
            }).AsNoTracking().ToListAsync();
            return Departments;
        }

        public async Task<DepartmentDetailsDto> GetDepartmentsByIdAsync(int id)
        {
            var Dept=await _unitOfWork.departmentRepository.GetByIdAsync(id);
            //if (Dept is not null) { equivlant
            if (Dept is { })
            {
                return new DepartmentDetailsDto()
                {
                    Id = Dept.Id,
                    Name = Dept.Name,
                    Description = Dept.Description,
                    Code = Dept.Code,
                    CreationDate = Dept.CreationDate,
                    CreatedBy = Dept.CreatedBy,
                    CreatedOn = Dept.CreatedOn,
                    LastModificationBy = Dept.LastModificationBy,
                    LastModificationOn = Dept.LastModificationOn,
                };
            }
            return null;
           
        }
        public async Task<int> CreateDepartmentAsync(CreateDepartmentDto Dept)
        {
            
            if (Dept is { })
            {
                var department= new Department()
                {
                    Id = Dept.Id,
                    Name = Dept.Name,
                    Description = Dept.Description,
                    Code = Dept.Code,
                    CreationDate = Dept.CreationDate,
                    CreatedBy = 1,
                    CreatedOn = Dept.CreatedOn,
                    LastModificationBy = 1,
                    LastModificationOn = DateTime.UtcNow,
                };
                 _unitOfWork.departmentRepository.Add(department);
                 return await _unitOfWork.CompleteAsync();

            }
            return 0;
        }
        public async Task<int> UpdateDepartmentAsync(UpdateDepartmentDto Dept)
        {

            if (Dept is { })
            {
                var department = new Department()
                {
                    Id = Dept.Id,
                    Name = Dept.Name,
                    Description = Dept.Description,
                    Code = Dept.Code,
                    CreationDate = Dept.CreationDate,
                    CreatedBy = 1,
                    CreatedOn = Dept.CreatedOn,
                    LastModificationBy = 1,
                    LastModificationOn = DateTime.UtcNow,
                };
                _unitOfWork.departmentRepository.Update(department);
                return await _unitOfWork.CompleteAsync();

            }
            return 0;
        }
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var DepartmentRepo = _unitOfWork.departmentRepository;
            var dept=await DepartmentRepo.GetByIdAsync(id);
            if(dept is { })
            {
                 DepartmentRepo.Delete(dept);
                return await _unitOfWork.CompleteAsync() > 0;
            }
            return false;
        }

       
    }
}
