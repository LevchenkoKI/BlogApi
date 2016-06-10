using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public class NewsService:INewsService
    {
       private IRepository<NewsEntry> _repository;

       public NewsService(IRepository<NewsEntry> repository) 
        {
            _repository = repository;
        }
        public void PostEntry(NewsEntry entry)
        {
            _repository.SaveInstance(entry);
        }
   
        public async Task<IEnumerable<NewsEntry>> GetAllNews()
        {
            return await _repository.GetFullRepository();
        }

        public Task<NewsEntry> GetNewsById(int NewsId)
        {
            return Task.FromResult(_repository.GetEntry(NewsId));
        }
    }
}
