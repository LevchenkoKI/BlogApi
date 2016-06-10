using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{

   public  class User
    {

         public User(int userId, string nickname)
         {
             UserId = userId;
             Nickname = nickname;

         }
         

        public int UserId { get; private set; }

        public string Nickname { get; private set; }
       
        
    }
}
