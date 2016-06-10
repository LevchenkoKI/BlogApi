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
    public class NewsServiceTests
    {

        [TestMethod]
        public async Task GetAllNews_WhenNoNews_ReturnsEmpty()

        {

            var repositoryStub=new Mock<IRepository<NewsEntry>>();
            repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(new List<NewsEntry>()));
            var newsservice = new NewsService(repositoryStub.Object);

            IEnumerable<NewsEntry> blogs = await newsservice.GetAllNews();

            Assert.AreEqual(blogs.Any(), false);
        }
        [TestMethod]
        public async Task GetAllNews_WhenhaveNews_ReturnsNews()
        {
            var repositorystub = new Mock<IRepository<NewsEntry>>();
            var newsList = new List<NewsEntry>
            {
              new NewsEntry(new User(0,""),DateTime.Now,new Rating(0,0),0,"1"   ),
             new NewsEntry(new User(0,""),DateTime.Now,new Rating(0,0),1,"2"   ),
              new NewsEntry(new User(0,""),DateTime.Now,new Rating(0,0),2,"3"   )
            };

            repositorystub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(newsList));
            var newsService = new NewsService(repositorystub.Object);



            Assert.AreEqual(newsList, await newsService.GetAllNews());
        }

        [TestMethod]
        public async Task GetNewsById_ZeroId_ReturnsZeroElement()
        {
            var repositorystub = new Mock<IRepository<NewsEntry>>();
            var expextedNewsEntry = new NewsEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 0, "ZeroElement");
            repositorystub.Setup(stub => stub.GetEntry(0)).Returns(expextedNewsEntry);
            var newsService = new NewsService(repositorystub.Object);



            Assert.AreEqual(expextedNewsEntry, await newsService.GetNewsById(0));
        }
        [TestMethod]
        public async Task GetNewsById_PlusId_ReturnsPlusElement()
        {
            var repositorystub = new Mock<IRepository<NewsEntry>>();
            var expextedNewsEntry = new NewsEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 1, "FirstElement");
            repositorystub.Setup(stub => stub.GetEntry(1)).Returns(expextedNewsEntry);
            var newsService = new NewsService(repositorystub.Object);



            Assert.AreEqual(expextedNewsEntry, await newsService.GetNewsById(1));
        }

    }
}
