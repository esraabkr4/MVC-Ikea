using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ikea.DAL.Models.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string UserName { get; set; } 
        public bool IsAgree { get; set; }
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string Email { get; set; }

    }
}
