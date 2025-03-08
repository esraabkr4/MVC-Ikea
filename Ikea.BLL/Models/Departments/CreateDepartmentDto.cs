using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Models.Departments
{
    public class CreateDepartmentDto
    {
        public int Id { get; set; }
        //public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        //public int LastModificationBy { get; set; }
        //public DateTime LastModificationOn { get; set; }
        //public bool IsDeleted { get; set; }
        [Required(ErrorMessage ="Code Is Required !!!")]
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "Name Is Required !!!")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name ="Date Of Creation")]
        public DateOnly CreationDate { get; set; }
    }
}
