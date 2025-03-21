﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Persistence.Repository.Departments;
using Ikea.DAL.Persistence.Repository.Employees;

namespace Ikea.DAL.Persistence.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        public IEmployeeRepository employeeRepository { get;  }
        public IDepartmentRepository departmentRepository { get;  }
        Task<int> CompleteAsync();

    }
}
