using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoolBlogCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolBlogCore.Services;
using System.Collections;
using System.Linq;


namespace CoolBlogCoreTests
{
    
        [TestClass]
        public class EntryRepositoryTests
        {
            [TestMethod]
            public async Task GetFullRepository_GetCountOfBlogs_RepositoryIsEmpty()
            {
                List<BlogEntry> list = await
                    EntryRepository<BlogEntry>.GetInstance().GetFullRepository();

                var ExeptedCount = 0;
                var actualCount = list.Count();

                Assert.AreEqual(ExeptedCount, actualCount);

            }

            [TestMethod]
            public void GetEntry_MinusId_ReturnsNull()
            {

                var blog = EntryRepository<BlogEntry>.GetInstance().GetEntry(-1);

                Assert.AreEqual(blog, null);

            }

            [TestMethod]
            public async Task GetEntry_ZeroId_ReturnsZeroElement()
            {
                List<BlogEntry> list = await
                   EntryRepository<BlogEntry>.GetInstance().GetFullRepository();
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 0, "ZeroElement"));
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 1, ""));

                var ExpextedBodyofBlog = "ZeroElement";
                var ActualBody=EntryRepository<BlogEntry>.GetInstance().GetEntry(0).Body;

                Assert.AreEqual(ExpextedBodyofBlog,ActualBody);

            }

            [TestMethod]
            public async Task GetEntry_SelectedId_ReturnsSelectBlog()
            {
                List<BlogEntry> list = await
                    EntryRepository<BlogEntry>.GetInstance().GetFullRepository();
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 0, ""));
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 1, "selected"));
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 2, ""));


                var ExpectedBodyOfBlog = "selected";
                var ActualBody = EntryRepository<BlogEntry>.GetInstance().GetEntry(1).Body;

                Assert.AreEqual(ExpectedBodyOfBlog, ActualBody);
            }
            [TestMethod]
            public async Task GetInstance_WhenObjectNotExist()
            {
                List<BlogEntry> list = await
                    EntryRepository<BlogEntry>.GetInstance().GetFullRepository();
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 0, ""));
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 1, "selected"));
                list.Add(new BlogEntry(new User(1, ""), DateTime.Now, new Rating(0, 0), 2, ""));


                var ExpectedBodyOfBlog = "selected";
                var ActualBody = EntryRepository<BlogEntry>.GetInstance().GetEntry(1).Body;

                Assert.AreEqual(ExpectedBodyOfBlog, ActualBody);
            }
            [TestMethod]
            public async Task SaveInstance()
            {

                var blogrepo = EntryRepository<BlogEntry>.GetInstance();
                var blogentryExpexted=new BlogEntry(new User(0,"jjhkj"),DateTime.Now, new Rating(0,0),0,"I'm blogentry"  );


                blogrepo.SaveInstance(blogentryExpexted);
                var AllRepo = await blogrepo.GetFullRepository();
                


                Assert.AreEqual(blogentryExpexted,AllRepo.Where(entry=>entry.Body=="I'm blogentry").ToList()[0]);
            }

        }
    }

