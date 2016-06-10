using CoolBlogCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoolBlogAPI.Models;

namespace CoolBlogAPI.Controllers
{
    public class NewsController : ApiController
    {
       NewsService newsService = new NewsService(EntryRepository<NewsEntry>.GetInstance());

        [HttpGet]
        [Route("api/news/")]
        public async Task<IEnumerable<BasicEntry>> GetNews()
        {
            return await newsService.GetAllNews();
        }
        [HttpGet]
        [Route("api/news/{id}")]
        public async Task<NewsEntry> GetNew(int id)
        {
            return await newsService.GetNewsById(id);

        }
        [HttpPost]
        [Route("api/news")]
        public IHttpActionResult PostNews([FromBody] News news)
        {
            IDentifier.currentID += 1;
            var newsEntry = new NewsEntry(Organization.GetInstance().FindUserByID(news.AuthorId), news.CreationTime, new Rating(0, 0), IDentifier.currentID, news.Body);
            newsService.PostEntry(newsEntry);
            return Ok("I did it");



        }
    }
}
