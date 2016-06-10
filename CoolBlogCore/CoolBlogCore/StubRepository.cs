using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public class StubRepository : IRepository<BasicEntry>
    {
        public List<BasicEntry> List = new List<BasicEntry>();


        public void SaveInstance(BasicEntry instance)
        {
            throw new NotImplementedException();
        }

        BasicEntry IRepository<BasicEntry>.GetEntry(int instanceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasicEntry>> GetFullRepository()
        {
            throw new NotImplementedException();
        }

        public void UpdateFile()
        {
            throw new NotImplementedException();
        }

        void IRepository<BasicEntry>.SaveInstance(BasicEntry instanse)
        {
            SaveInstance(instanse);
        }

        BasicEntry IReadonlyEntryRepository<BasicEntry>.GetEntry(int entryId)
        {
            throw new NotImplementedException();
        }
    }
}