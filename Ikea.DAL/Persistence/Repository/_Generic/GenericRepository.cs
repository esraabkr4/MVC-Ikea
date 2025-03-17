﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models;
using Ikea.DAL.Models.Departments;
using Ikea.DAL.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Ikea.DAL.Persistence.Repository._Generic
{
    public class GenericRepository<T> where T : ModelBase/*,IGenericRepository<T>*/
    {
        private protected readonly ApplicationDbContext dbContext;
        public GenericRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IEnumerable<T> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
                return dbContext.Set<T>().Where(X=>!X.IsDeleted).AsNoTracking().ToList();
            return dbContext.Set<T>().Where(X => !X.IsDeleted).ToList();


        }

        public T? GetById(int id)
        {
           
            return dbContext.Set<T>().Find(id);
        }
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            //return dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            //return dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            //return dbContext.SaveChanges();
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return dbContext.Set<T>().Where(X=>!X.IsDeleted);
        }
    }
}
