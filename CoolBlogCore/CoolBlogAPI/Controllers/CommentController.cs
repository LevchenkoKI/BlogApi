using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoolBlogCore;
using CoolBlogAPI.Models;
using System.Threading.Tasks;
namespace CoolBlogAPI.Controllers
{
    public class CommentController : ApiController
    {
        CommentService commentService = new CommentService(EntryRepository<Comment>.GetInstance());

        [HttpGet]
        [Route("api/comment/{id}")]
        public async Task<IEnumerable<BasicEntry>> GetAllComments(int id)
        {
            return await commentService.GetAllComments(id);
        }
       
        [HttpPost]
        [Route("api/comment/")]
        public IHttpActionResult PostComment([FromBody] CommentM comment)
        {
            IDentifier.currentID += 1;
            var commentEntry = new Comment(Organization.GetInstance().FindUserByID(comment.AuthorId), comment.CreationTime, new Rating(0, 0), IDentifier.currentID, comment.Body, comment.CommentingEntryId);
            commentService.PostEntry(commentEntry);


            return Ok("I did it");
        }
    }
}
