using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensibility;
namespace Repository.CSVTest
{
    [TestClass]
    public class ReadCSVLayoutTest
    {

        [TestMethod]
        public void ValidateRecordAlphaNumericTest()
        {

            string record = "768254873";

            var layout = new Layout

            {

                RecordName = "ID",
                LengthOfRecord = 9,
                TypeofRecord = "A\\N"

            };

            var expected = true;

            var result = ReadCSVLayout.ValidateRecord(record, layout);

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void ValidateRecordNumericTest()
        {

            string record = "20180101";

            var layout = new Layout

            {

                RecordName = "BirthDate",
                LengthOfRecord = 8,
                TypeofRecord = "N"

            };

            var expected = true;

            var result = ReadCSVLayout.ValidateRecord(record, layout);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ReadCSVFileTest()
        {

            string filePath  = @"D:\Applications\TestFiles\UserList.csv";

            var layout = Layout.ReadLayoutCSV(@"D:\Applications\TestFiles\CompanyLayout.csv");

            var records = ReadCSVLayout.ReadFile(filePath, layout);

            Assert.AreEqual(9, records.Count);
        }




    }
}
