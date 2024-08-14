using EmircanBlog_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Repositories.Abstract
{
    public interface IRepository<T> where T : class , IEntityBase , new()
    {
        Task AddAsync(T Entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includePropereties);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>> [] includeProperties);
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T Entity);  
       Task DeleteAsync(T Entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null);

        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
      




    }
}
