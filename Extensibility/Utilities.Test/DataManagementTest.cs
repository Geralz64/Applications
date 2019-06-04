using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.TestData;
namespace Utilities.Test
{
    [TestClass]
    public class DataManagementTest
    {

        [TestMethod]
        [DataRow("Hello", "               Hello")]
        [DataRow("MyName", "              MyName")]
        [DataRow("MyLastName", "          MyLastName")]
        [DataRow("Test", "                Test")]
        [DataRow("YEP", "                 YEP")]
        [DataRow("NUMbers476899", "       NUMbers476899")]
        public void FillWithSpacesTest(string data, string expected)
        {
            var result = DataManagement.FillWithSpaces(data, 20);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [DataRow("1234",      "0000001234")]
        [DataRow("2000",      "0000002000")]
        [DataRow("8995",      "0000008995")]
        [DataRow("6358",      "0000006358")]
        [DataRow("123859",    "0000123859")]
        [DataRow("123456789", "0123456789")]
        public void FillWithZerosTest(string data, string expected)
        {
            var result = DataManagement.FillWithZeros(data, 10);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void FormatRecordsTest()
        {

            var layout = LayoutTestData.TestData();

            var expected = MembershipTestData.FixedLengthTestData().ToList<string>();

            var records = MembershipTestData.CSVTestData();
            var result = DataManagement.FormatRecords(records, layout).ToList<string>();

            CollectionAssert.AreEqual(expected, result);

        }





    }
}
