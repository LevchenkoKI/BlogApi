using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore.ApplicationServices
{
  public  interface IEntryService<T> where T : BasicEntry
    {
        void PostEntry(T entry);
    }
}
