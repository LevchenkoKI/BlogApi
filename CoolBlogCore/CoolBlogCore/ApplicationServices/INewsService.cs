using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public interface INewsService
    {
       
        Task<IEnumerable<NewsEntry>> GetAllNews();
       Task< NewsEntry> GetNewsById(int NewsId);
    }
}
