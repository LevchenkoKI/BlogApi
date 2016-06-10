using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlogCore;

namespace CoolBlogCoreTests
{
    public class BlogRepositoryStub : IRepository<BlogEntry>
    {
        public List<BlogEntry> entries = new List<BlogEntry>();

        public void SaveInstance<T>(BlogEntry instanse)
        {
            entries.Add(instanse);
        }

        public T GetInstance<T>(int instanceId)
        {
            throw new NotImplementedException();
        }

        public void SaveInstance(BlogEntry instance)
        {
            throw new NotImplementedException();
        }

        BlogEntry IRepository<BlogEntry>.GetEntry(int instanceId)
        {
            throw new NotImplementedException();
        }

        public  Task<List<BlogEntry>> GetFullRepository()
        {
            return null;

        }

        public void UpdateFile()
        {
            throw new NotImplementedException();
        }

        void IRepository<BlogEntry>.SaveInstance(BlogEntry instanse)
        {
            SaveInstance(instanse);
        }

        BlogEntry IReadonlyEntryRepository<BlogEntry>.GetEntry(int entryId)
        {
            throw new NotImplementedException();
        }
    }
}
