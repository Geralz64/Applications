using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensibility;
using Utilities;
using Repository.TestData;

namespace Repository.CSVTest
{
    [TestClass]
    public class ReadCSVLayoutTest
    {
        [TestMethod]
        public void ReadCSVFileTest()
        {

            string filePath  = @"D:\Applications\TestFiles\CreateCSVLayoutFile.csv";

            var layout = Layout.ReadLayoutCSV(@"D:\Applications\TestFiles\CompanyLayout.csv");

            var memberInfo = MembershipTestData.TestData().OrderBy(x => x.MemberID);

            var list = new List<string>();
            foreach (var item in memberInfo)
            {

                list.Add(item.MemberID + "," + item.FirstName + "," + item.LastName + "," + item.SSN + "," + item.BirthDate + "," + item.StartDate + "," + item.EndDate);
                
            }

            var expected = list.First();

            var result = ReadCSVLayout.ReadFile(filePath, layout).First();

            Assert.AreEqual(expected, result);

        }




    }
}
