using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcBlog.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcBlog.Bussiness.Tests
{
    [TestClass()]
    public class UyelikServiceTests
    {
        /*
        [TestMethod()]
        public void UyelikServiceTest()
        {
            Assert.Fail();
        }
        */

        [TestMethod()]
        public void RetrieveUyeByIdTest()
        {
            //ImvcblogDB db = new Moq

            Mock<mvcblogDB> moqDb = new Mock<mvcblogDB>();
            var data = new List<Uye>
            {
                new Uye{
                    UyeId = 1
                },
                new Uye{
                    UyeId = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Uye>>();
            
            mockSet.As<IQueryable<Uye>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Uye>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Uye>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockSet.As<IQueryable<Uye>>().Setup(m => m.GetEnumerator()).Returns(0 => data.GetEnumerator());

            var mockContext = new Mock<mvcblogDB>();
            mockContext.Setup(c => c.Uyes).Returns(mockSet.Object);

            var service = new UyelikService(mockContext.Object);
            var uye = service.RetrieveUyeById(1);
            Assert.AreEqual(2, uye.UyeId);
        }
    }
}