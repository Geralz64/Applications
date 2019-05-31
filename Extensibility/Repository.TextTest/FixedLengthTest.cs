using System;
using System.Collections.Generic;
using System.IO;
using Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.FixedLengthFile;

namespace Repository.TextTest
{
    [TestClass]
    public class FixedLengthTest
    {
        [TestMethod]
        public void CreateFileTest()
        {
            var layout = new List<Layout>() {

                new Layout { RecordName = "MemberID", LengthOfRecord = 10, TypeofRecord = "N" },
                new Layout { RecordName = "Name", LengthOfRecord = 20, TypeofRecord = "AN" },
                new Layout { RecordName = "LastName", LengthOfRecord = 20, TypeofRecord = "AN" },
                new Layout { RecordName = "BirthDate", LengthOfRecord = 10, TypeofRecord = "N" },
                new Layout { RecordName = "SSN", LengthOfRecord = 10, TypeofRecord = "N" }

            };

            var list = new List<string> {

                "768254873,Samuel,Carlu,19610126,12964642",
                "561752142,Ignác,Lyuba,19970630,171883451",
                "456272089,Hermes,Milena,20131118,158764459",
                "861487492,Ulric,Snorre,20191010,145211845",
                "468440653,Andrea,Diana,19560127, 170327476",
                "464570109,Lykos,Temir,19580421,127733635",
                "728413373,Dustin,Imke,19780817,129661852",
                "103634937,Andela,Ingeburg,19790814,117570340",
                "741060277,Paul,Henrike,19791011,158985165"

            };
            var fileInfo = new FileInformation<string>();
            fileInfo.Records = list;

            fileInfo.FileLocation = @"D:\Applications\TestFiles\";
            fileInfo.FileName = "FixedLengthTest.txt";

            

            //FixedLength<string>.CreateFile(fileInfo, layout);

            var expected = true;

            var result = File.Exists(fileInfo.FileLocation + fileInfo.FileName);

            Assert.AreEqual(expected, result);
        }
    }
}
