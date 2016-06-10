using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoolBlogCore;
using CoolBlogAPI.Models;
using System.Threading.Tasks;
using CoolBlogCore.Services;

namespace CoolBlogAPI.Controllers
{
    public class BlogController : ApiController
    {
        BlogService blogService = new BlogService(EntryRepository<BlogEntry>.GetInstance());

        [HttpGet]
        [Route("api/blog/")]
        public async Task<IEnumerable<BasicEntry>> GetBlogs()
        {
            
            return  await blogService.GetAllBlogs();
        }
        [HttpGet]
        [Route("api/blog/{id}")]
        public async Task<BlogEntry> GetBlog(int id)
        {
            return await blogService.GetBlogById(id);

        }
        [HttpPost]
        [Route("api/blog/")]
        public  IHttpActionResult PostBlog([FromBody]Blog blog)
        {
            IDentifier.currentID += 1;
            var blogEntry=new BlogEntry(Organization.GetInstance().FindUserByID(blog.AuthorId),blog.CreationTime,new Rating(0,0),IDentifier.currentID,blog.Body  );
            blogService.PostEntry(blogEntry);
            
            return Ok("I did it");



        }


    }
}
