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
        Task<IEnumerable<T>> GetAllAsync(bool WithNoTracking = true);
        Task<T?> GetByIdAsync(int id);
        void Add(T emp);
        void Update(T emp);
        void Delete(T emp);
        IQueryable<T> GetAllAsQueryable();
    }
}
