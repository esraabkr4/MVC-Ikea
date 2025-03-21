﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Common;
using Ikea.DAL.Models.Departments;

namespace Ikea.DAL.Models.Employees
{
    public class Employee:ModelBase
    {
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmpType empType { get; set; }
        #region Department
        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public string? Image { get; set; }
        #endregion
    }
}
