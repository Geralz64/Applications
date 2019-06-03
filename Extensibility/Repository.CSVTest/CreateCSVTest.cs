using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.TestData;
namespace Repository.CSVTest
{

    [TestClass]
    public class CreateCSVTest
    {
        [TestMethod]
        public void CreateCSVFileTest()
        {

            var fileInformation = new Utilities.FileInformation<MembershipTestData>();

            fileInformation.FileLocation = @"D:\Applications\TestFiles\";

            fileInformation.FileName = "CreateCSVLayoutFile.csv";

            fileInformation.Delimiter = ",";

            var testData = MembershipTestData.TestData();

            fileInformation.Records = testData;

            CreateCSV<MembershipTestData>.CreateFile(fileInformation);

            bool success = File.Exists(fileInformation.FileLocation + fileInformation.FileName);

            Assert.IsTrue(success);

        }

    }
}
