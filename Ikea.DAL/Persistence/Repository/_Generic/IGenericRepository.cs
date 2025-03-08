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
        int Add(T emp);
        int Update(T emp);
        int Delete(T emp);
        IQueryable<T> GetAllAsQueryable();
    }
}
