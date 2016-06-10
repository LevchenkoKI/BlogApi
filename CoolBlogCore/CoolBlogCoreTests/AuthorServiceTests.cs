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
    public class AuthorServiceTests
    {
        [TestMethod]
        public async Task GetAllAuthorsBlogs_WhenAuthorHasBlogs()
        {

            var repositoryStubBlogs = new Mock<IRepository<BlogEntry>>();
            var repositoryStubComments = new Mock<IRepository<Comment>>();
            var author = new User(1, "Sam");
            var blog1 = new BlogEntry(author, DateTime.Now, new Rating(0, 0), 0, "1");
            var blog2 = new BlogEntry(author, DateTime.Now, new Rating(0, 0), 1, "2");
            var bloglist = new List<BlogEntry>
            {
                blog1,
                blog2,

                new BlogEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 2, "3")
            };


            repositoryStubBlogs.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(bloglist));
            var authorService = new AuthorService(repositoryStubBlogs.Object, repositoryStubComments.Object);
            var ExpextedList = new List<BlogEntry>
            {
                blog1,
                blog2
            };


            Assert.AreEqual((await authorService.GetAllAuthorsBlogs(1)).ToList()[0], ExpextedList[0]);
            Assert.AreEqual((await authorService.GetAllAuthorsBlogs(1)).ToList()[1], ExpextedList[1]);




        }

        [TestMethod]
        public async Task GetAllAuthorsBlogs_WhenAuthorDontHasBlogs()
        {

            var repositoryStubBlogs = new Mock<IRepository<BlogEntry>>();
            var repositoryStubComments = new Mock<IRepository<Comment>>();
            var author = new User(1, "Sam");

            var bloglist = new List<BlogEntry>
            {

                new BlogEntry(new User(0, ""), DateTime.Now, new Rating(0, 0), 2, "3")
            };


            repositoryStubBlogs.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(bloglist));
            var authorService = new AuthorService(repositoryStubBlogs.Object, repositoryStubComments.Object);



            Assert.AreEqual((await authorService.GetAllAuthorsBlogs(1)).Any(), false);





        }

        [TestMethod]
        public async Task GetAllAuthorsComments_WhenAuthorHasComments()
        {

            var repositoryStubBlogs = new Mock<IRepository<BlogEntry>>();
            var repositoryStubComments = new Mock<IRepository<Comment>>();
            var author = new User(1, "Sam");
            var comment1 = new Comment(author, DateTime.Now, new Rating(0, 0), 0, "1", 7);
            var comment2 = new Comment(author, DateTime.Now, new Rating(0, 0), 1, "2", 4);
            var comments = new List<Comment>
            {
                comment1,
                comment2,

                new Comment(new User(0, ""), DateTime.Now, new Rating(0, 0), 2, "3", 5)
            };


            repositoryStubComments.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(comments));
            var authorService = new AuthorService(repositoryStubBlogs.Object, repositoryStubComments.Object);
            var ExpextedList = new List<Comment>
            {
                comment1,
                comment2
            };
            Assert.AreEqual((await authorService.GetAllAuthorsComments(1)).ToList()[0], ExpextedList[0]);
            Assert.AreEqual((await authorService.GetAllAuthorsComments(1)).ToList()[1], ExpextedList[1]);

        }
        [TestMethod]
        public async Task GetAllAuthorsComments_WhenAuthorDontHasComments()
        {

            var repositoryStubBlogs = new Mock<IRepository<BlogEntry>>();
            var repositoryStubComments = new Mock<IRepository<Comment>>();
            var author = new User(1, "Sam");

            var comments = new List<Comment>
            {

                new Comment(new User(0, ""), DateTime.Now, new Rating(0, 0), 2, "3",5)
            };


            repositoryStubComments.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(comments));
            var authorService = new AuthorService(repositoryStubBlogs.Object, repositoryStubComments.Object);



            Assert.AreEqual((await authorService.GetAllAuthorsComments(1)).Any(), false);


        }
        [TestMethod]
        public async Task GetBlogsOrderedByDate_ReturnOrderedList()
        {
            var repositoryList = new List<BlogEntry>
            {
               new BlogEntry(new User(0,"Sam"), DateTime.MinValue, new Rating(0, 0), 0, "1"),
               new BlogEntry(new User(1,"Sam"), DateTime.Now, new Rating(0, 0), 1, "2"),
            new BlogEntry(new User(2,"Sam"), DateTime.MaxValue, new Rating(0, 0), 2, "3")
                
            };
            var shuffledList = repositoryList.OrderBy(entry => Guid.NewGuid()).ToList();
            var repositoryStubBlogs = new Mock<IRepository<BlogEntry>>();
            var repositoryStubComment=new Mock<IRepository<Comment>>();
            repositoryStubBlogs.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(shuffledList));
            
            var authorService=new AuthorService(repositoryStubBlogs.Object,repositoryStubComment.Object);
            var actualList= await authorService.OrderByForDate(shuffledList);


            Assert.AreEqual(repositoryList[0].EntryID,actualList.ToList()[0].EntryID );
            Assert.AreEqual(repositoryList[1].EntryID, actualList.ToList()[1].EntryID);
            Assert.AreEqual(repositoryList[2].EntryID, actualList.ToList()[2].EntryID);
        }

        [TestMethod]
        public async Task WroteBlogs_HasntBlogs_ReturnFalse()
        {
            var repositoryList = new List<BlogEntry>
            {
               new BlogEntry(new User(0,"Sam"), DateTime.MinValue, new Rating(0, 0), 0, "1"),
               new BlogEntry(new User(1,"Sam"), DateTime.Now, new Rating(0, 0), 1, "2"),
            new BlogEntry(new User(2,"Sam"), DateTime.MaxValue, new Rating(0, 0), 2, "3")
                
            };
            var author=new User(7,"Barak");
            var repositoryStub=new Mock<IRepository<BlogEntry>>();
            repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(repositoryList));
            var authorService=new AuthorService(repositoryStub.Object,new Mock<IRepository<Comment>>().Object);


           var actual= await authorService.WroteBlogs(7);
            var expected = false;

            Assert.AreEqual(expected,actual);

        }

        [TestMethod]
        public async Task WroteBlogs_HasBlogs_ReturnTrue()
        {
            var author = new User(7, "Barak");
            var repositoryList = new List<BlogEntry>
            {
                new BlogEntry(author, DateTime.MinValue, new Rating(0, 0), 0, "1"),
                new BlogEntry(new User(1, "Sam"), DateTime.Now, new Rating(0, 0), 1, "2"),
                new BlogEntry(new User(2, "Sam"), DateTime.MaxValue, new Rating(0, 0), 2, "3")

            };

            var repositoryStub = new Mock<IRepository<BlogEntry>>();
            repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(repositoryList));
            var authorService = new AuthorService(repositoryStub.Object, new Mock<IRepository<Comment>>().Object);


            var actual = await authorService.WroteBlogs(7);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

       [TestMethod]
        public async Task GetAllAuthorsBlogsWithLimit()
        {
            var author = new User(7, "Barak");
            var blog1 = new BlogEntry(author, DateTime.MinValue, new Rating(0, 0), 0,
                "ewffffffffffffffffffffffffffffffwwefewwww1");
            var blog2 = new BlogEntry(author, DateTime.Now, new Rating(0, 0), 1,
                "2ewffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
            var blog3 = new BlogEntry(author, DateTime.MaxValue, new Rating(0, 0), 2, "3");
            var repositoryList = new List<BlogEntry>
            {
              blog1,blog2,blog3

            };

            var repositoryStub = new Mock<IRepository<BlogEntry>>();
            repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(repositoryList));
            var authorService = new AuthorService(repositoryStub.Object, new Mock<IRepository<Comment>>().Object);


            var actualList = await authorService.GetAllAuthorsBlogsWithLimit(7, 10);
            var expextedList = new List<BlogEntry> {blog3};

            Assert.AreEqual(expextedList[0],actualList.ToList()[0]);
           Assert.IsFalse(actualList.Contains(blog1));
           Assert.IsFalse(actualList.Contains(blog2));

        }
        [TestMethod]
       public async Task GetAllAuthorsBlogsWithLimit_WhenLimitMinus_ReturnsEmptyList()
       {
           var author = new User(7, "Barak");
           var blog1 = new BlogEntry(author, DateTime.MinValue, new Rating(0, 0), 0,
               "ewffffffffffffffffffffffffffffffwwefewwww1");
           var blog2 = new BlogEntry(author, DateTime.Now, new Rating(0, 0), 1,
               "2ewffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff");
           var blog3 = new BlogEntry(author, DateTime.MaxValue, new Rating(0, 0), 2, "3");
           var repositoryList = new List<BlogEntry>
            {
              blog1,blog2,blog3

            };

           var repositoryStub = new Mock<IRepository<BlogEntry>>();
           repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(repositoryList));
           var authorService = new AuthorService(repositoryStub.Object, new Mock<IRepository<Comment>>().Object);


           var actualList = await authorService.GetAllAuthorsBlogsWithLimit(7, -1);
           

          
            Assert.AreEqual(actualList.Any(),false);
       }

       
    }
}
