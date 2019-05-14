using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Extensibility
{
    public  static class ReadCSVLayout
    {

        public static List<string[]> ReadCSVFile(string filePath, List<Layout> layout)
        {

            string data = File.ReadAllText(filePath);

            var list = new List<string[]>();
            bool isValid = true;

            foreach (string row in data.Split('\n'))
            {

                var layoutLine = new Layout();
                var records = row.Split(',');
                int count = 0;

                foreach (var item in records)
                {

                    layoutLine = layout.ElementAt(count);
                    isValid = ValidateRecord(item, layoutLine);

                    if (isValid == false)
                    {
                        break;
                    }

                    count += 1;
                }

                if (isValid == true)
                {
                    list.Add(records);
                }
                else
                {
                    //Insert records into other file, into db or into another file for verification 
                }

            }

            return list;
        }
        public static bool ValidateRecord(string record, Layout recordLayout)
        {

            bool isValid = true;

            int length = recordLayout.LengthOfRecord;
            string recordType = recordLayout.TypeofRecord;


            if (record.Length > length)
            {
                isValid = false;
            }

            if (recordType == "N")
            {
                int check = Regex.Matches(record, @"[a-zA-Z]").Count;

                isValid = check > 0 ? false : true;
            }


            return isValid;
        }

       



    }
}
