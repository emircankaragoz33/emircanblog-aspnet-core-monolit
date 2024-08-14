using EmircanBlog_Data.Context;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmircanContext _emircanContext;

        public UnitOfWork(EmircanContext emircanContext)
        {
            _emircanContext = emircanContext;
        }
        public async ValueTask DisposeAsync()
        {
            await _emircanContext.DisposeAsync();   
        }

        public Task<int> SaveAsync()
        {
           return _emircanContext.SaveChangesAsync();
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(_emircanContext);
        }
    }
}
