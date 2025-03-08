using System.ComponentModel.DataAnnotations;

namespace Ikea.PL.Models.Departments
{
    public class DepartmentEditVM
    {
        [Required(ErrorMessage = "Code Is Required !!!")]
        public string Code { get; set; } = null!;
        [Required(ErrorMessage = "Name Is Required !!!")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
