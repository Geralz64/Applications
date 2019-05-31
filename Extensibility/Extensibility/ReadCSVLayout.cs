using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities;
namespace Extensibility
{
    public static class ReadCSVLayout
    {

        public static List<string> ReadFile(string filePath, List<Utilities.Layout> layout)
        {

            string data = File.ReadAllText(filePath);

            var list = new List<string>();
            bool isValid = true;

            foreach (string row in data.Split('\n'))
            {

                var layoutLine = new Layout();
                var records = row.Split(',');
                int count = 0;

                foreach (var item in records)
                {

                    layoutLine = layout.ElementAt(count);

                    //layoutLine = layout.ElementAt(count);
                    isValid = Utilities.DataManagement.ValidateRecord(item, layoutLine);

                    if (isValid == false)
                    {
                        break;
                    }

                    count += 1;
                }

                if (isValid == true)
                {
                    list.Add(row);
                }

            }

            return list;
        }


       



    }
}
