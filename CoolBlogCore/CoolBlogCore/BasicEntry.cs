using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{




    public class BasicEntry
    {
     
        public string Body { get; private set; }

      
        public User Owner { get; private set; }
   
        public DateTime CreationDate { get; private set; }

    
        public Rating Rating { get; private set; }

        public int EntryID { get; private set; }
       
        public BasicEntry(User owner, DateTime creationDate, Rating rating, int entryID,string body)
        {
            CreationDate = creationDate;
            Rating = rating;
            EntryID = entryID;
            Body = body;
            Owner = owner;
        }

      
    }
}
