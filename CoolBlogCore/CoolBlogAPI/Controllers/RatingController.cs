using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoolBlogAPI.Models;
using CoolBlogCore;
using CoolBlogCore.Services;

namespace CoolBlogAPI.Controllers
{
    public class RatingController : ApiController
    {
        RatingService<BlogEntry> ratingServiceBlog = new RatingService<BlogEntry>(EntryRepository<BlogEntry>.GetInstance());
        RatingService<Comment> ratingServiceComment = new RatingService<Comment>(EntryRepository<Comment>.GetInstance());
        RatingService<NewsEntry> ratingServiceNews = new RatingService<NewsEntry>(EntryRepository<NewsEntry>.GetInstance());
        [HttpGet]
        [Route("api/rating/{id}/{typeEntry}")]
        public int? GetRating(int id,string typeEntry)
        {
            switch (typeEntry)
            {
                case "blog":
                    return ratingServiceBlog.GetRating(id);
          
                case "comment":
                    return ratingServiceComment.GetRating(0);
                case "news":
                    return ratingServiceNews.GetRating(0);
            }
            return null;
        }
      
        [HttpPost]
        [Route("api/rating/{id}/upvote/{typeEntry}")]
        public IHttpActionResult Upvote(int id,string typeEntry)
        {
            switch (typeEntry)
            {
                case "blog":
                     ratingServiceBlog.UpVote(id);
                    break;

                case "comment":
                     ratingServiceComment.UpVote(id);
                    break;
                case "news":
                    ratingServiceNews.UpVote(id);
                    break;
                    
            }
            
            return Ok("I upvoted" + id);
        }

        [HttpPost]
        [Route("api/rating/{id}/downvote/{typeEntry}")]
        public IHttpActionResult Downvote(int id, string typeEntry)
        {
            switch (typeEntry)
            {
                case "blog":
                    ratingServiceBlog.DownVote(id);
                    break;

                case "comment":
                    ratingServiceComment.DownVote(id);
                    break;
                case "news":
                    ratingServiceNews.DownVote(id);
                    break;

            }
            return Ok("I downvoted" + id);
        }

       
    }
}
