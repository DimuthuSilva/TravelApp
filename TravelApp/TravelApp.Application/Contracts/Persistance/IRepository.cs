using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TravelApp.Application.Contracts.Persistance
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<T> GetByIdAsync(object id);

        Task InsertAsync(T obj);

        void Update(T obj);

        Task DeleteAsync(object id);

        void DeleteAsync(T entityToDelete);
    }
}
