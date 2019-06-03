using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Repository.TestData;
namespace Repository.TextTest
{

    [TestClass]
    public class SingleLineText
    {


        [TestMethod]
        public void CrateFileTest()
        {

            var layout = LayoutTestData.TestData();

            var list = MembershipTestData.CSVTestData();
            var fileInfo = new FileInformation<string>();
            fileInfo.Records = list;

            fileInfo.FileLocation = @"D:\Applications\TestFiles\";
            fileInfo.FileName = "SingleLineTest.txt";

            SingleLine<string>.CreateFile(fileInfo, list, layout);

            var expected = true;

            var result = File.Exists(fileInfo.FileLocation + fileInfo.FileName);


            Assert.AreEqual(result, expected);

        }

    }
}
