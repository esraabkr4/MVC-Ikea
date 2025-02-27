﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.BLL.Models.Departments
{
    public class UpdateDepartmentDto
    {
        public int Id { get; set; }
        //public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        //public int LastModificationBy { get; set; }
        //public DateTime LastModificationOn { get; set; }
        //public bool IsDeleted { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
