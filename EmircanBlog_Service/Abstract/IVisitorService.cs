using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmircanBlog_Service.Abstract
{
    public interface IVisitorService
    {
        Task<int> IncrementVisitorCountServiceAsync();
        Task<int> GetVisitorCountAsync();
    }
}
