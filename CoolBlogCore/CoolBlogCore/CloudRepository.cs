using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public class CloudRepository : IRepository<BasicEntry>
    {


        public void SaveInstance(BasicEntry instanse)
        {
            throw new NotImplementedException();
        }

        public BasicEntry GetEntry(int instanceId)
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
    }
}