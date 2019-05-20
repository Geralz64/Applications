using Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CSVTest
{

    [TestClass]
    public class CreateCSVTest
    {
        [TestMethod]
        public void CreateCSVFileTest()
        {

            var fileInformation = new FileInformation<MemberInfo>();

            fileInformation.FileLocation = @"D:\Applications\TestFiles\";

            fileInformation.FileName = "CreateCSVLayoutFile.csv";

            fileInformation.Delimiter = ",";

            fileInformation.Records = new List<MemberInfo>() {

                new MemberInfo { MemberId = "768254873" ,Name = "Samuel" },
                new MemberInfo { MemberId = "561752142", Name = "Ignác" },
                new MemberInfo { MemberId = "456272089", Name = "Hermes" },
                new MemberInfo { MemberId = "861487492", Name = "Ulric" },
                new MemberInfo { MemberId = "468440653", Name = "Andrea" },
                new MemberInfo { MemberId = "464570109", Name = "Lykos" },
                new MemberInfo { MemberId = "728413373", Name = "Dustin" },
                new MemberInfo { MemberId = "103634937", Name = "Andela" },
                new MemberInfo { MemberId = "741060277", Name = "Paul" }


            };

            CreateCSV<MemberInfo>.CreateFile(fileInformation);

            bool success = File.Exists(fileInformation.FileLocation + fileInformation.FileName);

            Assert.IsTrue(success);

        }


        public class MemberInfo {

            public string MemberId { get; set; }

            public string Name { get; set; }



        }




    }
}
