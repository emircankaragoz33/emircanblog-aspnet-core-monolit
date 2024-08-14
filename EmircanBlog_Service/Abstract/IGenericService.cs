using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Abstract
{
    public interface IGenericService<T>
    {
        Task AddAsyncService (T Entity);
        Task<List<T>> GetAllAsyncService (Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includePropereties);
        Task<T> GetAsyncService (Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByGuidAsyncService (Guid id);
        Task<T> UpdateAsyncService (T Entity);
        Task DeleteAsyncService (T Entity);
        Task<bool> AnyAsyncService (Expression<Func<T, bool>> filter = null);

        Task<int> CountAsyncService(Expression<Func<T, bool>> filter = null);
    }
}
