using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore.ApplicationServices
{
  public  interface IBlogService : IEntryService<BlogEntry>
    {
        Task<IEnumerable<BlogEntry>> GetAllBlogs();
        Task<BlogEntry> GetBlogById(int id);
    }
}
