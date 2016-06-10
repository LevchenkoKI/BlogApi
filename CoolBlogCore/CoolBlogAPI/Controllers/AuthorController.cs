using CoolBlogCore;
using CoolBlogCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoolBlogAPI.Controllers
{
    public class AuthorController : ApiController
    {
        AuthorService authorService = new AuthorService(EntryRepository<BlogEntry>.GetInstance(), EntryRepository<Comment>.GetInstance());

        [HttpGet]
        [Route("api/author/{id}/blogs/")]
        public async Task<IEnumerable<BasicEntry>> GetAllAuthorsBlogs(int id)
        {
            return await authorService.GetAllAuthorsBlogs(id);
        }
        [HttpGet]
        [Route("api/author/{id}/blogs/{limit}/")]
        public async Task<IEnumerable<BasicEntry>> GetAllAuthorsBlogsWithLimit(int id, int limit)
        {
            return await authorService.GetAllAuthorsBlogsWithLimit(id, limit);

        }
        [HttpGet]
        [Route("api/author/{id}/comments/")]
        public async Task<IEnumerable<BasicEntry>> GetAllAuthorsComments(int id)
        {
            return await authorService.GetAllAuthorsComments(id);

        }
        [HttpGet]
        [Route("api/author/blogs/{id}/wrote/")]
        public async Task<bool> WroteBlogs(int id)
        {
            return await authorService.WroteBlogs(id);

        }
        [HttpPost]
        [Route("api/author/blogs/orderby/")]
   
        public IHttpActionResult OrderbyForDate([FromBody] IEnumerable<BlogEntry> entries)
        {
            authorService.OrderByForDate(entries);
            return Ok("I did it");



        }
    }
}
