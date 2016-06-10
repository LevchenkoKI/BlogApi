using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore.ApplicationServices
{
    public interface IAuthorService
    {
        Task<IEnumerable<BlogEntry>> GetAllAuthorsBlogs(int userId);
        Task<IEnumerable<BlogEntry>> GetAllAuthorsBlogsWithLimit(int userId, int limit);
        Task<IEnumerable<Comment>> GetAllAuthorsComments(int userId);
        Task<bool> WroteBlogs(int userId);
        Task<IEnumerable<BlogEntry>> OrderByForDate(IEnumerable<BlogEntry> entries);

    }
}
