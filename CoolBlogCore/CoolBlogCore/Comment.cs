using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{

    public class Comment : BasicEntry
    {
        
        public int CommentingEntryId { get; private set; }
        public Comment(User owner, DateTime creationDate, Rating rating, int EntryID,string body,int commentingEntryId):base (owner,creationDate,rating,EntryID,body)
        {
            CommentingEntryId = commentingEntryId;
             
        }
        
    }
}
