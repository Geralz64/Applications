using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
   public class CreateCSV
    {

        private static string FileLocation { get; set; }
        private static bool HasHeader { get; set; }
        private static string Delimiter { get; set; }


        //public void CreateFile()
        //{
        //    string fileFullPath = FileLocation + FileName;

        //    using (var writer = new StreamWriter(fileFullPath))
        //    {
        //        using (var csv = new CsvWriter(writer))
        //        {
        //            csv.Configuration.HasHeaderRecord = HasHeader;
        //            csv.Configuration.Delimiter = Delimiter;

        //            csv.WriteRecords(Items);
        //        }
        //    }
        //}

    }
}
