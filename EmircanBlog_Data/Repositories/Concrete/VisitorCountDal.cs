using EmircanBlog_Data.Context;
using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Repositories.Concrete
{
    public class VisitorCountDal : IVisitorCountDal
    {
        private EmircanContext _emircanContext;
        public VisitorCountDal(EmircanContext emircanContext)
        {
            _emircanContext  = emircanContext;
        }
        public async Task<int> IncrementVisitorCountAsync()
        {
            var counter = await _emircanContext.Visitors.FirstOrDefaultAsync();

            if (counter == null)
            {
                counter = new Visitor { Count = 1 };
                _emircanContext.Visitors.Add(counter);
            }

            else
            {
                counter.Count++;
                _emircanContext.Visitors.Update(counter);
            }

            await _emircanContext.SaveChangesAsync();
            return counter.Count;
        }

        public async Task<int> GetVisitorCountAsync()
        {
            var counter = await _emircanContext.Visitors.FirstOrDefaultAsync();
            return counter?.Count ?? 0;
        }
    }
}
