using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolBlogAPI.Models
{
    public class CommentM
    {

        public int AuthorId { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
        public int CommentingEntryId { get; set; }
    }
}