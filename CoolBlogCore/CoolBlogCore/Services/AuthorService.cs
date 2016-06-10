using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlogCore.ApplicationServices;

namespace CoolBlogCore.Services
{
   public class AuthorService:IAuthorService
    {
       private IRepository<BlogEntry> _repositoryBlogs;
       private IRepository<Comment> _repositoryComments;
       public AuthorService(IRepository<BlogEntry> repositoryB,IRepository<Comment> repositoryC) 
       {
           _repositoryBlogs = repositoryB;
           _repositoryComments = repositoryC;
       }


       public async Task<IEnumerable<BlogEntry>> GetAllAuthorsBlogs(int userId)
       {
           IEnumerable<BlogEntry> blogs=await _repositoryBlogs.GetFullRepository();
           
         return  blogs.Where(entries => entries.Owner.UserId == userId);
       }

       public async Task<IEnumerable<BlogEntry>> GetAllAuthorsBlogsWithLimit(int userId, int limit)
       {
           IEnumerable<BlogEntry> blogs = await GetAllAuthorsBlogs(userId);
           return blogs.Where(entry => entry.Body.Length < limit);
       }

       public async Task<IEnumerable<Comment>> GetAllAuthorsComments(int userId)
       {
           IEnumerable<Comment> comments = await _repositoryComments.GetFullRepository();
           return comments.Where(comment => comment.Owner.UserId == userId);
       }

       public async Task<bool> WroteBlogs(int userId)
       {
           IEnumerable<BlogEntry> blogs = await GetAllAuthorsBlogs(userId);
           return blogs.Count()!=0;
       }

       public   Task<IEnumerable<BlogEntry>> OrderByForDate(IEnumerable<BlogEntry> entries)
       {
           
           return  Task.FromResult((IEnumerable<BlogEntry>)entries.OrderBy(entry => entry.CreationDate));
       }
    }
}
