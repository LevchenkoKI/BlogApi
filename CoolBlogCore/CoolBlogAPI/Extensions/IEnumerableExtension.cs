using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoolBlogAPI.Models;

namespace CoolBlogAPI.Extensions
{
    public static class IEnumerableExtension
    {
        public static void ForEach(IEnumerable<Blog> Collection,Action<Blog> action)
        {
        
            foreach(var i in Collection)
            {
                action(i);

            }
            
        }
    }
}