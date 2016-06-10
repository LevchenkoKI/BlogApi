using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public interface IUpdatableEntryRepository<T> where T : BasicEntry
    {
        void SaveInstance(T instance);
    }
}