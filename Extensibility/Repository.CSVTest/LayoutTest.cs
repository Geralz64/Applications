using System;
using System.IO;
using System.Linq;
using CsvHelper;
using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.SQL;
using Utilities;

namespace Repository.CSVTest
{
    [TestClass]
    public class LayoutTest
    {

        [TestMethod]
        public void ReadLayoutCSVTest()
        {

            string filePath = @"D:\Applications\TestFiles\CompanyLayout.csv";

            var layout = Layout.ReadLayoutCSV(filePath);

            string recordName = "ID";
            int lengthOfRecord = 9;
            string typeOfRecord = "A\\N";


            Assert.AreEqual(recordName, layout.ElementAt(0).RecordName);
            Assert.AreEqual(lengthOfRecord, layout.ElementAt(0).LengthOfRecord);
            Assert.AreEqual(typeOfRecord, layout.ElementAt(0).TypeofRecord);

        }


    }
}
