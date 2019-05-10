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
                layoutLine.TypeofRecord = records[2];

                layout.Add(layoutLine);

            }

            return layout;

        }

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

                    isValid = ValidateValue(item[count].ToString(), layoutLine);

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


        private static bool ValidateValue(string record, Layout recordLayout)
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

                isValid = !Regex.IsMatch(record, @"^[a-zA-Z]+$");

            }


            return isValid;
        }




    }
}
