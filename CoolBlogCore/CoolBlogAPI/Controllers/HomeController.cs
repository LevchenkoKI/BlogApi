using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CoolBlogAPI.Controllers
{
    public class HomeController : ApiController
    {
        public string GetSomething()
        {
            return "Something";
        }
    }
}
