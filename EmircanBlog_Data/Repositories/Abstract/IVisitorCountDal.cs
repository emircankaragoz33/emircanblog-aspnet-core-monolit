using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Data.Repositories.Abstract
{
    public interface IVisitorCountDal 
    {
        Task<int> IncrementVisitorCountAsync();
       Task<int> GetVisitorCountAsync();
    }
}
