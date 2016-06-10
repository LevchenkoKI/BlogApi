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
  public  class BlogServiceTests
    {
      [TestMethod]
        public async Task GetAllBlogs_WhenhaveBlogs_ReturnsBlogs()
        {
            var repositorystub = new Mock<IRepository<BlogEntry>>();
            var bloglist = new List<BlogEntry>
            {
              new BlogEntry(new User(0,""),DateTime.Now,new Rating(0,0),0,"1"   ),
             new BlogEntry(new User(0,""),DateTime.Now,new Rating(0,0),1,"2"   ),
              new BlogEntry(new User(0,""),DateTime.Now,new Rating(0,0),2,"3"   )
            };

            repositorystub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(bloglist));
            var blogservice = new BlogService(repositorystub.Object);

            

            Assert.AreEqual(bloglist,await blogservice.GetAllBlogs());
        }

        [TestMethod]
        public async Task GetBlogById_ZeroId_ReturnsZeroElement()
        {
            var repositorystub = new Mock<IRepository<BlogEntry>>();
            BlogEntry expextedBlogEntryblog=new BlogEntry(new User(0,""),DateTime.Now, new Rating(0,0),0,"ZeroElement"  );
            repositorystub.Setup(stub => stub.GetEntry(0)).Returns(expextedBlogEntryblog);
          var blogservise=new BlogService(repositorystub.Object);



            Assert.AreEqual(expextedBlogEntryblog,await blogservise.GetBlogById(0));
        }
        [TestMethod]
        public async Task GetBlogById_PlusId_ReturnsPlusElement()
        {
            var repositorystub = new Mock<IRepository<BlogEntry>>();
            BlogEntry expextedBlogEntryblog = new BlogEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 1, "FirstElement");
            repositorystub.Setup(stub => stub.GetEntry(1)).Returns(expextedBlogEntryblog);
            var blogservise = new BlogService(repositorystub.Object);



            Assert.AreEqual(expextedBlogEntryblog, await blogservise.GetBlogById(1));
        }

    }
}
