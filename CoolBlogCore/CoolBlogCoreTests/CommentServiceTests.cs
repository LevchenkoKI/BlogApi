using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlogCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoolBlogCoreTests
{
    [TestClass]
   public class CommentServiceTests
    {
        [TestMethod]
        public async Task GetALLComments_WhenHaveComments()
        {
            var comment1 = new Comment(new User(0, ""), DateTime.Now, new Rating(0, 0), 0, "1", 1);
            var comment2 = new Comment(new User(0, ""), DateTime.Now, new Rating(0, 0), 1, "2", 1);
            var commentList=new List<Comment>
            {
                comment1,comment2,new Comment(new User(0,""),DateTime.Now,new Rating(0,0),2,"3" ,0  )
            };
            var repositoryStub=new Mock<IRepository<Comment>>();
            repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(commentList));
            var  commentService=new CommentService(repositoryStub.Object);


            var ActualListOfComments = await commentService.GetAllComments(1);
            var ExpextedListOfComments=new List<Comment>{comment1,comment2};

            Assert.AreEqual(ExpextedListOfComments[0], ActualListOfComments.ToList()[0]);
            Assert.AreEqual(ExpextedListOfComments[1], ActualListOfComments.ToList()[1]);
            
        }

        [TestMethod]
        public async Task GetALLComments_WhenNoComments()
        {
            var comment1 = new Comment(new User(0, ""), DateTime.Now, new Rating(0, 0), 0, "1", 1);
            var comment2 = new Comment(new User(0, ""), DateTime.Now, new Rating(0, 0), 1, "2", 1);
            var commentList = new List<Comment>
            {
                comment1,comment2,new Comment(new User(0,""),DateTime.Now,new Rating(0,0),2,"3" ,0  )
            };
            var repositoryStub = new Mock<IRepository<Comment>>();
            repositoryStub.Setup(stub => stub.GetFullRepository()).Returns(Task.FromResult(commentList));
            var commentService = new CommentService(repositoryStub.Object);


            var ActualListOfComments = await commentService.GetAllComments(5);
            var ExpextedListOfComments = new List<Comment> { comment1, comment2 };
            
            Assert.AreEqual(false,ActualListOfComments.Any());

        }
    }
}
