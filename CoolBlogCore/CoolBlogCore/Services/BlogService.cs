using System.Collections.Generic;
using System.Threading.Tasks;
using CoolBlogCore.ApplicationServices;

namespace CoolBlogCore.Services
{
    public class BlogService : IBlogService
    {
        private IRepository<BlogEntry> _repository;

        public BlogService(IRepository<BlogEntry> repository)
        {
            _repository = repository;
        }
        public void PostEntry(BlogEntry entry)
        {
            _repository.SaveInstance(entry);
        }
        public async Task<IEnumerable<BlogEntry>> GetAllBlogs()
        {
            return await _repository.GetFullRepository();
        }

        public Task<BlogEntry> GetBlogById(int id)
        {
            return Task.FromResult(_repository.GetEntry(id));
        }
    }
}