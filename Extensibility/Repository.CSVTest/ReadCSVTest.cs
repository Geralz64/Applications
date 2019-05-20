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
            string FileLocation = @"D:\TestFiles\MemberLocal.csv";
            bool HasHeader = true;
            string Delimiter = ",";


            ReadCSV<MemberTest> readCSV = new ReadCSV<MemberTest>(FileLocation, HasHeader, Delimiter);


            var member = readCSV.ReadFile();

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


