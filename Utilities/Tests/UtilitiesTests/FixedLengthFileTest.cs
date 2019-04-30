using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;


namespace UtilitiesTests
{
    [TestClass]
    public class FixedLengthFileTest
    {

        [TestMethod]
        public void FillWithSpacesRight()
        {


            FixedLengthFile value = new FixedLengthFile
            {
                Record = "Test",
                Direction = Direction.Right,
                Length = 10
            };

            var expected = "Test      ";

            var result = FixedLengthFile.FillWithSpaces(value);
            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        public void FillWithSpacesLeft()
        {


            FixedLengthFile value = new FixedLengthFile
            {
                Record = "Test",
                Direction = Direction.Left,
                Length = 10
            };

            var expected = "      Test";

            var result = FixedLengthFile.FillWithSpaces(value);
            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        public void FillWithZerosRight()
        {

            FixedLengthFile value = new FixedLengthFile
            {
                Record = "1111",
                Direction = Direction.Right,
                Length = 10
            };

            var expected = "1111000000";

            var result = FixedLengthFile.FillWithZeros(value);
            Assert.AreEqual(expected, result);

        }


        [TestMethod]
        public void FillWithZerosLeft()
        {

            FixedLengthFile value = new FixedLengthFile
            {
                Record = "1111",
                Direction = Direction.Left,
                Length = 10
            };

            var expected = "0000001111";

            var result = FixedLengthFile.FillWithZeros(value);
            Assert.AreEqual(expected, result);

        }


    }


}

