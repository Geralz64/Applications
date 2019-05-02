using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repository.CSVTest
{
    [TestClass]
    public class CSVTest
    {
        [TestMethod]
        public void FilesWithInfoTest()
        {
            var expected = new string[,]
            {
               { "File1", "2" },
               { "File2","2"}


            };



        }
    }
}
