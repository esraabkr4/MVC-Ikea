using AutoMapper;
using Ikea.BLL.Models.Departments;
using Ikea.BLL.Models.Employees;
using Ikea.PL.Models.Departments;

namespace Ikea.PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region Employee
            CreateMap<EmployeeDetailsDTO, UpdateEmployeeDTO>();
            #endregion
            #region Department
            CreateMap<DepartmentDetailsDto, DepartmentEditVM>()
                .ReverseMap();
            CreateMap<DepartmentEditVM, UpdateDepartmentDto>();

            #endregion
        }

    }
}
