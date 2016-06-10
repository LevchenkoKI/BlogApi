using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public interface IRepository<T> : IUpdatableEntryRepository<T>, IReadonlyEntryRepository<T> where T : BasicEntry
    {

        void SaveInstance(T instanse);
        T GetEntry(int instanceId);
        Task<List<T>> GetFullRepository();
        void UpdateFile();
    }
}