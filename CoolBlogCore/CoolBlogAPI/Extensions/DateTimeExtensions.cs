using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolBlogAPI.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToBeatifulString(this DateTime dateTime) 
        {
            var beautifulString = '[' + dateTime.ToShortDateString() + ']';
            return beautifulString;
        }
    }
}