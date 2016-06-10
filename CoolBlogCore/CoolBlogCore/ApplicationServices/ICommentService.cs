using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public interface ICommentService
    {
       
        Task<IEnumerable<Comment>> GetAllComments(int Entryid);
    }
}
