using CoolBlogCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoolBlogAPI.Controllers
{
    public class TestController : ApiController
    {
        EntryRepository<BlogEntry> blogs;
        EntryRepository<Comment> comments;

        [HttpGet]
        [Route("api/test")]
        public int Test()
        {
            blogs = EntryRepository<BlogEntry>.GetInstance();
            comments = EntryRepository<Comment>.GetInstance();
            comments.SaveInstance(new Comment(null,DateTime.Now,null,1,"test",1));
            EntryRepository<Comment> comments2 = EntryRepository<Comment>.GetInstance();
            if (comments != comments2)
            {
                throw new Exception();
            }

            Comment comment = comments2.GetEntry(1);
            if (!comment.Body.Equals("test"))
            {
                throw new Exception();
            }
            return 1;
        }
    }
}
