using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NW.Entity;

namespace SmallCode.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Log log = new Log();
            log.Level = "asdasd";

            Console.WriteLine(log.GetType().Name);
            //Console.ReadKey();
        }
    }
}
