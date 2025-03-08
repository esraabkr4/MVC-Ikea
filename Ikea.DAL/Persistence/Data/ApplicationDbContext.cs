using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection;
using Ikea.DAL.Models.Employees;

namespace Ikea.DAL.Persistence.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //old method used before dependency injection
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;DataBase=IkeaDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region dbSets
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion
    }
}
