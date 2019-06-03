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
    public class ReadFixedLengthTest
    {

        [TestMethod]
        public void ReadFixedLengthFileTest()
        {
            var fileInfo = new FileInformation<string>();

            fileInfo.FileLocation = @"D:\Applications\TestFiles\";
            fileInfo.FileName = "FixedLengthTest.txt";

            var expected = MembershipTestData.FixedLengthTestData();

            var result = ReadFixedLength<string>.ReadFile(fileInfo).ToList<string>();

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
