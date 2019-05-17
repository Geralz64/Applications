using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extensibility
{
    public class Layout
    {
        public string RecordName { get; set; }
        public int LengthOfRecord { get; set; }
        public string TypeofRecord { get; set; }
        public static List<Layout> ReadLayoutCSV(string filePath)
        {

            var layout = new List<Layout>();

            string data = File.ReadAllText(filePath);

            foreach (string row in data.Split('\n'))
            {

                var layoutLine = new Layout();

                var records = row.Split(',');

                layoutLine.RecordName = records[0];
                layoutLine.LengthOfRecord = Convert.ToInt32(records[1]);
                layoutLine.TypeofRecord = records[2].Replace("\r","");

                layout.Add(layoutLine);

            }

            return layout;

        }

    }
}
