using EmircanBlog_Core;
using EmircanBlog_Data.Context;
using EmircanBlog_Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class , new()
    {
        private readonly EmircanContext _emircanContext;

        public GenericRepository(EmircanContext emircanContext)
        {
            _emircanContext = emircanContext;
        }

        private DbSet<T> Table { get=> _emircanContext.Set<T>(); }

        public async Task AddAsync(T Entity)
        {
            await Table.AddAsync(Entity);
          
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await Table.AnyAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, int>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>>  GetAllAsync(Expression<Func<T,bool>> filter = null , params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();       


        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            if (filter != null)
            {
                query = query.Where(filter);

            }

            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {

                    query = query.Include(item);
                }
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
           var entity =  await Table.FindAsync(id);
            return entity;
        }

        public async Task<T> UpdateAsync(T Entity)
        {
            await Task.Run(() =>
            {
                Table.Update(Entity);
            });

            return Entity;
        }
    }
}
