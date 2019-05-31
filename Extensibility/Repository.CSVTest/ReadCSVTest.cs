using System;
using System.IO;
using CsvHelper;
using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.SQL;
using System.Linq;
namespace Repository.CSVTest
{
    [TestClass]
    public class ReadCSVTest
    {

        [TestMethod]
        public void ReadFileTest()
        {

            var fileInfo = new Utilities.FileInformation<MemberTest>();
     
            fileInfo.FileLocation = @"D:\TestFiles\MemberLocal.csv";
            fileInfo.FileLocation = "MemberLocal.csv";
            fileInfo.HasHeader = true;
            fileInfo.Delimiter = ",";

            var member = ReadCSV<MemberTest>.ReadFile(fileInfo);

            string result = member.Select(m => m.Name).First();

            string expected = "100";

            Assert.AreEqual(result, expected);
        }
    }

}

public class MemberTest
    {
        public string Name { get; set; }

        public string Number { get; set; }

    }


