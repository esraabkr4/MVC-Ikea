using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.BLL.Models.Departments;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Persistence.Repository.Departments;
using Microsoft.EntityFrameworkCore;

namespace Ikea.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        public IDepartmentRepository DepartmentRepo;

        public DepartmentService(IDepartmentRepository _departmentRepo)
        {
            DepartmentRepo = _departmentRepo;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            //var Departments = DepartmentRepo.GetAll();
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
            var Departments = DepartmentRepo.GetAllAsQueryable().Select(dept => new DepartmentDto()
            {
                Id = dept.Id,
                Name = dept.Name,
                Description = dept.Description,
                Code = dept.Code,
                CreationDate = dept.CreationDate
            }).AsNoTracking().ToList();
            return Departments;
        }

        public DepartmentDetailsDto GetDepartmentsById(int id)
        {
            var Dept=DepartmentRepo.GetById(id);
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
        public int CreateDepartment(CreateDepartmentDto Dept)
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
                return DepartmentRepo.Add(department);

            }
            return 0;
        }
        public int UpdateDepartment(UpdateDepartmentDto Dept)
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
                return DepartmentRepo.Update(department);

            }
            return 0;
        }
        public bool DeleteDepartment(int id)
        {
            var dept=DepartmentRepo.GetById(id);
            if(dept is { })
            {
                return DepartmentRepo.Delete(dept)>0;
            }
            return false;
        }

       
    }
}
