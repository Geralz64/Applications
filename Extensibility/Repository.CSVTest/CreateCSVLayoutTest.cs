using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CSVTest
{

    [TestClass]
    public class CreateCSVLayoutTest
    {

        [TestMethod]
        public void CreateCSVLayoutFileTest()
        {

            var layout = new List<Layout>() {

                new Layout { RecordName = "Member", LengthOfRecord = 7, TypeofRecord = "N" },
                new Layout { RecordName = "Price", LengthOfRecord = 7, TypeofRecord = "N\\A" },
                new Layout { RecordName = "BirthDate", LengthOfRecord = 7, TypeofRecord = "N" },
                new Layout { RecordName = "SSN", LengthOfRecord = 7, TypeofRecord = "N\\A" },
                new Layout { RecordName = "Age", LengthOfRecord = 7, TypeofRecord = "N" }

            };

            var fileInformation = new CSVFileInformation<Layout>
            {
                FileLocation = @"D:\Applications\TestFiles\",

                FileName = "CreateCSVLayoutFileTest.csv",

                Delimiter = "|",

                HasHeader = true,

                Records = layout
            };

            CreateCSVLayout<Layout>.CreateCSVLayoutFile(fileInformation);

            bool success = File.Exists(fileInformation.FileLocation + fileInformation.FileName);

            Assert.IsTrue(success);
        }
    }

}
