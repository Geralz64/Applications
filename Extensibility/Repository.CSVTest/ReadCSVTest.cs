using System;
using System.IO;
using CsvHelper;
using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.SQL;

namespace Repository.CSVTest
{
    [TestClass]
    public class ReadCSVTest
    {

        [TestMethod]
        public void ReadFileTestWithSQL()
        {
            string FileLocation = "D:\\TestFiles\\NewMembers.csv";
            bool HasHeader = true;
            string Delimiter = ",";


            ReadCSV<Member> test = new ReadCSV<Member>(FileLocation, HasHeader, Delimiter);


            var Person = test.ReadFile();

            foreach (var item in Person)
            {

                Console.WriteLine($"Person Name: {item.BirthDate}");

            }
            Assert.AreEqual(1, 2);
        }



        [TestMethod]
        public void ReadFileLocalNoDataBase()
        {
            string FileLocation = "D:\\TestFiles\\MemberLocal.csv";
            bool HasHeader = true;
            string Delimiter = ",";


            ReadCSV<MemberTest> test = new ReadCSV<MemberTest>(FileLocation, HasHeader, Delimiter);


            var Person = test.ReadFile();

            foreach (var item in Person)
            {

                Console.WriteLine($"Person Name: {item.Name}");

            }

            Assert.AreEqual(1, 2);
        }





    }


}


public class MemberTest
    {
        public string Name { get; set; }

        public string Number { get; set; }

    }


