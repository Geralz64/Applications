using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.FixedLengthFile;
using Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;


namespace Repository.TextTest
{
    [TestClass]
    public class ReadSingleLineTest
    {        

        [TestMethod]
        public void ReadLineTest()
        {

            var fileInfo = new FileInformation<string>();

            fileInfo.FileLocation = @"D:\Applications\TestFiles\";
            fileInfo.FileName = "SingleLineTest.txt";

            var expected = MembershipTestData.SingleLineTestData();

            var result = ReadSingleLine<string>.ReadFile(fileInfo);

            Assert.AreEqual(expected, result);

        }


    }
}
