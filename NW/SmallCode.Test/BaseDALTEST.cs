using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NW.DAL;
using NW.Entity;
using System.Collections.Generic;
using System.Linq;

namespace SmallCode.Test
{
    [TestClass]
    public class BaseDALTEST
    {
        [TestMethod]
        public void TestMethod1()
        {
            LogDAL dal = new LogDAL();
            Log log = new Log { Thread = "1", Exception = "Test", Description = "test", Time = DateTime.Now };
            int result = dal.Insert(log);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SourceWebDAL dal = new SourceWebDAL();
            SourceWeb web = new SourceWeb { CreateDate = DateTime.Now,CreateBy=1,Web="test",URL="www.test.com",IsDelete=false };
            int result = dal.Insert(web);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SourceWebDAL dal = new SourceWebDAL();
            //SourceWeb web = new SourceWeb { CreateDate = DateTime.Now, CreateBy = 1, Web = "test", URL = "www.test.com", IsDelete = false };
            int result = dal.Delete(3);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            SourceWebDAL dal = new SourceWebDAL();
            SourceWeb web = new SourceWeb {Id=1,CreateDate = DateTime.Now, CreateBy = 1, Web = "test222", URL = "www.testtest.com", IsDelete = true };
            int result = dal.Update(web);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            SourceWebDAL dal = new SourceWebDAL();
            SourceWeb web = dal.GetEntity(1);
            Console.WriteLine(web.Web);
        }

        [TestMethod]
        public void TestMethod6()
        {
            SourceWebDAL dal = new SourceWebDAL();
            List<SourceWeb> webs = dal.GetList("").ToList();
            foreach (var item in webs)
            {
                Console.WriteLine(item.Web);
            }
        }

    }
}
