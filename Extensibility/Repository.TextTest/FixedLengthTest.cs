using System;
using System.Collections.Generic;
using System.IO;
using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.FixedLengthFile;
using Repository.TestData;

namespace Repository.TextTest
{
    [TestClass]
    public class FixedLengthTest
    {
        [TestMethod]
        public void CreateFileTest()
        {

            var list = MembershipTestData.TestData();

            var fileInfo = new FileInformation<string>();

            var formatedList = new List<string>();
            foreach (var item in list)
            {
                formatedList.Add(item.MemberID + "," + item.FirstName + "," + item.LastName + "," + item.SSN + "," + item.BirthDate + "," + item.StartDate + "," + item.EndDate);
            }

            fileInfo.Records = formatedList;

            fileInfo.FileLocation = @"D:\Applications\TestFiles\";
            fileInfo.FileName = "FixedLengthTest.txt";

            var layout = LayoutTestData.TestData();
            
            FixedLength<string>.CreateFile(fileInfo, layout);

            var expected = true;

            var result = File.Exists(fileInfo.FileLocation + fileInfo.FileName);

            Assert.AreEqual(expected, result);
        }
    }
}
