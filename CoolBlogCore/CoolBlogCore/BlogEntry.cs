using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
    
    public class BlogEntry : BasicEntry
    {
        public BlogEntry(User owner, DateTime creationDate, Rating rating, int EntryID,string body):base (owner,creationDate,rating,EntryID,body)
        {
         
        }
       
    }
}
