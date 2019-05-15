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

            var fileInformation = new CSVFileInformation<string>();

            fileInformation.FileLocation = @"D:\Applications\TestFiles\";

            fileInformation.FileName = "CreateCSVLayoutFile.csv";

            fileInformation.Records = new List<string>

            {

                "768254873,Samuel,Carlu,19610126,129646423,Hammer,Testor, Dense,843.00,59",
                "561752142,Ignác,Lyuba,19970630,171883451,Knife,Magic,Dense,20.00,25",
                "456272089,Hermes,Milena,20131118,158764459,Brush,Testor,Dense,15.00,56",
                "861487492,Ulric,Snorre,20191010,145211845,Knife,Non stain,Dense,800.00 ,100",
                "468440653,Andrea,Diana,19560127, 170327476, Hammer,Testor,Light,256.00,85",
                "464570109,Lykos,Temir,19580421,127733635,Ruler,Balit,Dense,700.00,200",
                "728413373,Dustin,Imke,19780817,129661852,Ruler,Testor,Dense,100.00,15",
                "103634937,Andela,Ingeburg,19790814, 117570340,3D printer,Solid,Dense,359.00,125",
                "741060277,Paul,Henrike,19791011,158985165,EVA foam,Testor,Dense , 203.00,95"

            };

             CreateCSV<string>.CreateCSVFile(fileInformation);


            bool success = File.Exists(fileInformation.FileLocation + fileInformation.FileName);

            Assert.IsTrue(success);

        }



    }
}
