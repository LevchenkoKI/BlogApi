using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    public class CommentService : ICommentService
    {
        private IRepository<Comment> _repository;
        public CommentService(IRepository<Comment> repository) 
        {
            _repository = repository;
        }


        public void PostEntry(Comment entry)
        {
            _repository.SaveInstance(entry);
        }

        public async Task<IEnumerable<Comment>> GetAllComments(int Entryid)
        {
           
            IEnumerable<Comment> comments= await _repository.GetFullRepository();
            return comments.Where(comment => comment.CommentingEntryId == Entryid);
        }

       
    }
}