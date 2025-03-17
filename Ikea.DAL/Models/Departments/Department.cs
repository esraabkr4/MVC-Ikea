using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Employees;

namespace Ikea.DAL.Models.Departments
{
    public class Department:ModelBase
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
        #region Employee
        public virtual ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
        #endregion
    }
}
