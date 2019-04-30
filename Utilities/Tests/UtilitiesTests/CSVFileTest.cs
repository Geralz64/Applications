using System;
using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace UtilitiesTests
{
    [TestClass]
    public class CSVFileTest
    {

        [TestMethod]
        public void ReadCSVFileTest()
        {

            var csvReader = new CSVFile<Member>
            {
                FileName = "Member.txt",

                FileLocation = "D:\\Applications\\TestFiles\\",

                HasHeader = true

            };


            var result = CSVFile<Member>.ReadCSVFile(csvReader);

            var expected = new List<Member>

            {

                new Member {Name = "Geraldo", LastName = "Duran Izquierdo", DOB = 20180101}

            };

            Assert.AreEqual(expected.Select(x => x.Name).First().ToString(), result.Select(x => x.Name).First().ToString());


        }

        [TestMethod]
        public void CreateCSVFileTest()
        {



        }



    }

}
