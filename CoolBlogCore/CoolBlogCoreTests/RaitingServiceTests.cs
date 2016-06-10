using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlogCore;
using CoolBlogCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoolBlogCoreTests
{
    [TestClass]
   public class RaitingServiceTests
    {
        [TestMethod]
        public void UpVote_WhenEntryThereIs()
        {
            var repositoryStub = new Mock<IRepository<BlogEntry>>();
            var blog = new BlogEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 0, "");
        
            repositoryStub.Setup(stub => stub.GetEntry(0)).Returns(blog);
            var ratingService = new RatingService<BlogEntry>(repositoryStub.Object);

            ratingService.UpVote(0);

            Assert.AreEqual(1, blog.Rating.Sum);

        }

        [TestMethod]
        public void UpDown_WhenEntryThereIs()
        {
            var repositoryStub = new Mock<IRepository<BlogEntry>>();
            var blog = new BlogEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 0, "");
            repositoryStub.Setup(stub => stub.GetEntry(0)).Returns(blog);
            var ratingService = new RatingService<BlogEntry>(repositoryStub.Object);

            ratingService.DownVote(0);

            Assert.AreEqual(-1, blog.Rating.Sum);

        }

        [TestMethod]
        public void GetRating_WhenEntryThereIs()
        {
            var repositoryStub = new Mock<IRepository<BlogEntry>>();
            var blog = new BlogEntry(new User(0, ""), DateTime.Now, new Rating(10, 5), 0, "");
            repositoryStub.Setup(stub => stub.GetEntry(0)).Returns(blog);
            var ratingService = new RatingService<BlogEntry>(repositoryStub.Object);
            var actualRating = ratingService.GetRating(0);
            var exeptedRating = 5;

            Assert.AreEqual(exeptedRating, actualRating);

        }
        [TestMethod]
        public void GetRating_WhenEntryNo()
        {
            var repositoryStub = new Mock<IRepository<BlogEntry>>();
            repositoryStub.Setup(stub => stub.GetEntry(0)).Returns(value: null);

            var ratingService = new RatingService<BlogEntry>(repositoryStub.Object);

            Assert.AreEqual(null, ratingService.GetRating(0));

        }

       
    }
}
