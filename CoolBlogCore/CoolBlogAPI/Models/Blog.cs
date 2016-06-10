using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoolBlogCore;

namespace CoolBlogAPI.Models
{
    public class Blog
    {
        public int AuthorId { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }



    }
}