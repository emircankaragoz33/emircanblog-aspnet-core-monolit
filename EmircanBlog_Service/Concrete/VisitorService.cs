using EmircanBlog_Data.Repositories.Abstract;
using EmircanBlog_Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Concrete
{
    public class VisitorService : IVisitorService
    {
        IVisitorCountDal _visitorCountDal;

        public VisitorService(IVisitorCountDal visitorCountDal)
        {
                _visitorCountDal     = visitorCountDal;
        }

        public async Task<int> GetVisitorCountAsync()
        {
          return  await _visitorCountDal.GetVisitorCountAsync();
        }

        public async Task<int> IncrementVisitorCountServiceAsync()
        {
           return await _visitorCountDal.IncrementVisitorCountAsync();  
        }
    }
}
