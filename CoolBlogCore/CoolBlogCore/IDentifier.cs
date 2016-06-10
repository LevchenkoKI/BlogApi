using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlogCore
{
  public    class IDentifier
    {
      private static IDentifier instance;
      public static IDentifier GetInstance()
      {
          if (instance == null)
          {
              instance = new IDentifier();
          }
          return instance;
      }
      private IDentifier()
      {
          currentID = -1;
      }
      public static int currentID { get; set; }

    }
}
