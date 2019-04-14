using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, 3);

        }


        [TestMethod]
        public void ComputeHighestGrade()
        {

            GradeBook book = new GradeBook();

            book.AddGrade(90);
            book.AddGrade(60);

            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(90, stats.HighestGrade);

        }

        [TestMethod]
        public void ComputeLowestGrade()
        {

            GradeBook book = new GradeBook();

            book.AddGrade(90);
            book.AddGrade(60);

            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(60, stats.LowestGrade);

        }

        [TestMethod]
        public void ComputeAverageGrade()
        {

            GradeBook book = new GradeBook();

            book.AddGrade(90);
            book.AddGrade(90);

            GradeStatistics stats = book.ComputeStatistics();

            Assert.AreEqual(90, stats.HighestGrade);

        }




    }


}
