using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Common;
using Microsoft.AspNetCore.Http;

namespace Ikea.BLL.Models.Employees
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Too Long Name!!! Max Length Of Name Is Only 50 Chars")]
        [MinLength(2, ErrorMessage = "Too Short Name!!! Min Length Of Name Is 2 Chars")]
        public string Name { get; set; } = null!;
        [Range(22, 60)]
        public int? Age { get; set; }
        [RegularExpression(@"\d+\s[\w\s]+,\s[\w\s]+,\s[A-Za-z]{2}\s\d{5}$", ErrorMessage = "Your Address Must Be Like '123 Main Street, Springfield, IL 62701'")]
        public string? Address { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; } = null!;
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmpType empType { get; set; }
        #region Administration
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModificationBy { get; set; }
        public DateTime LastModificationOn { get; set; }
        #endregion
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public IFormFile Image { get; set; }
    }
}
