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
        Task<List<T>> GetAllAsyncService ();
        Task<T> GetAsyncService (Guid id);
        Task<T> GetByGuidAsyncService (Guid id);
        Task<T> UpdateAsyncService (T Entity);
        Task DeleteAsyncService (T Entity);
        Task<bool> AnyAsyncService (Guid id);

        //Task<int> CountAsyncService();
    }
}
