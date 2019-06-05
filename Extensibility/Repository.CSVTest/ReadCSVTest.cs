using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.TestData;
using System.Collections.Generic;
using System.Linq;
namespace Repository.CSVTest
{
    [TestClass]
    public class ReadCSVTest
    {

        [TestMethod]
        public void ReadFileTest()
        {

            var fileInfo = new Utilities.FileInformation<MembershipTestData>();

            fileInfo.FileLocation = @"D:\Applications\TestFiles\";
            fileInfo.FileName = "ReadFileTest.csv";
            fileInfo.HasHeader = false;
            fileInfo.Delimiter = ",";

            var expected = MembershipTestData.TestData().OrderBy(x => x.MemberID);

            var expectedList = new List<string>();

            foreach (var item in expected)
            {

               expectedList.Add( item.MemberID + item.FirstName + item.LastName + item.SSN + item.BirthDate + item.StartDate + item.EndDate);

            }

            var result = ReadCSV<MembershipTestData>.ReadFile(fileInfo).OrderBy(x => x.MemberID);

            var resultList = new List<string>();

            foreach (var item in result)
            {
                resultList.Add(item.MemberID + item.FirstName + item.LastName + item.SSN + item.BirthDate + item.StartDate + item.EndDate);
            }

            CollectionAssert.AreEquivalent(expectedList, resultList);

        }
    }

}


