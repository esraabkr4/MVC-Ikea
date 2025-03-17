using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ikea.DAL.Models.Employees;
using Ikea.DAL.Common;

namespace Ikea.DAL.Persistence.Data.Configurations.Employees
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
      

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(E => E.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(E => E.gender).HasConversion(
                (gender) => (gender).ToString(),
                (gender) => (Gender)Enum.Parse(typeof(Gender), gender)
                );
            builder.Property(E => E.empType).HasConversion(
                (type) => (type).ToString(),
                (type) => (EmpType)Enum.Parse(typeof(EmpType), type)
                );

        }
    }
}
