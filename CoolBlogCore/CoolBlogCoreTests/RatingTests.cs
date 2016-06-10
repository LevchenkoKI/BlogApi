using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlogCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolBlogCoreTests
{
    [TestClass]
   public class RatingTests
    {
        [TestMethod]
        public void UpVote()
        {
            var rating=new Rating(0,0);

            rating.UpVote();

            Assert.AreEqual(1,rating.Sum);

        }
        [TestMethod]
        public void DownVote()
        {
            var rating = new Rating(0, 0);

            rating.DownVote();

            Assert.AreEqual(-1, rating.Sum);

        }


    }
}
