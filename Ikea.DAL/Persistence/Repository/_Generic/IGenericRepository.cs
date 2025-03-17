using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ikea.DAL.Models;

namespace Ikea.DAL.Persistence.Repository._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        IEnumerable<T> GetAll(bool WithNoTracking = true);
        T? GetById(int id);
        void Add(T emp);
        void Update(T emp);
        void Delete(T emp);
        IQueryable<T> GetAllAsQueryable();
    }
}
