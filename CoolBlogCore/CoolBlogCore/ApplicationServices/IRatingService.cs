using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public interface IRatingService
    {
        void UpVote(int EntryId);
        void DownVote(int EntryId);
    }
}
