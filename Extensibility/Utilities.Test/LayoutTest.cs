using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Test
{
    [TestClass]
    public class LayoutTest
    {

        [TestMethod]
        public void ReadLayoutCSVTest()
        {
            var expected = LayoutTestData.TestData();
            var expectedList = new List<string>();
            foreach (var item in expected)
            {
                expectedList.Add(item.RecordName + "," + item.LengthOfRecord + "," + item.TypeofRecord);
            }

            var result = Layout.ReadLayoutCSV(@"D:\Applications\TestFiles\CompanyLayout.csv");
            var resultList = new List<string>();
            foreach (var item in result)
            {
                resultList.Add(item.RecordName + "," + item.LengthOfRecord + "," + item.TypeofRecord);
            }

            CollectionAssert.AreEquivalent(expectedList, resultList);



        }

    }
}
