using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Common;

namespace Ikea.DAL.Models.Employees
{public class Employee:ModelBase
    {
        public string Name { get; set; } = null!;
        public string? Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmpType empType { get; set; }
    }
}
