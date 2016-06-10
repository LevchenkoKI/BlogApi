using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public interface IReadonlyEntryRepository<T> where T : BasicEntry
    {
        T GetEntry(int instanceId);
    }
}
