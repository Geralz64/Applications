using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;
namespace Utilities.Test
{
    [TestClass]
    public class UtilitiesTest
    {
        [TestMethod]
        public void LogInfoStartTest()
        {
            var expected = "LogInfoStartTest";
            string result = Utilities.LogInfoStart();

            Assert.AreEqual(result, expected);

        }






    }
}
