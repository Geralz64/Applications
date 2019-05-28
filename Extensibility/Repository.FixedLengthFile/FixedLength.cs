using Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FixedLengthFile
{
    public class FixedLength<T>
    {


        /*
         What do I want to do:
              
        Create single line fixed length file
        - Create a file thats multiple records in one single line one after the other like the standards in some companies

        Read single line fixed length file
        -Divide by counting the amount of spaces between each line and then separating OR by a specific segment

        As a final note consolidate some of the code I used on the CSV classes maybe instead of a csv file I can use it to create any
        type of file by using the extension and that way I have less code to maintain. Probably create a FileManagement class 
        instead and add the CSV file classes inside this way I'll have less project libraries 


         */

        public static void CreateFile(FileInformation<T> fileInfo, List<Layout> layout)
        {
            List<string> formatedRecords = FormatRecords(fileInfo, layout);

            WriteFile(fileInfo, formatedRecords);

        }

        private static List<string> FormatRecords(FileInformation<T> fileInfo, List<Layout> layout)
        {
            var formatedRecords = new List<string>();

            foreach (var line in fileInfo.Records)
            {
                var lineSegments = line.ToString().Split(',');
                var formatedLine = String.Empty;

                for (int i = 0; i < lineSegments.Count(); i++)
                {
                    string segment = lineSegments[i].ToString();

                    int lenghtOfRecord = layout.ElementAt(i).LengthOfRecord;
                    string typeOfRecord = layout.ElementAt(i).TypeofRecord;

                    string formatedSegment = (typeOfRecord == "AN") ? FillWithSpaces(segment, lenghtOfRecord) : FillWithZeros(segment, lenghtOfRecord);

                    formatedLine += formatedSegment;

                }

                formatedRecords.Add(formatedLine);
            }

            return formatedRecords;
        }

        private static void WriteFile(FileInformation<T> fileInfo, List<string> formatedRecords)
        {
            using (var writer = new StreamWriter(fileInfo.FileLocation + fileInfo.FileName))
            {
                foreach (var record in formatedRecords)
                {
                    writer.WriteLine(record);
                }
                writer.Close();

            }
        }

        private static string FillWithSpaces(string segment, int padding)
        {

            segment = segment.PadLeft(padding);

            return segment;

        }
        public static string FillWithZeros(string segment, int padding)
        {

            segment = segment.PadLeft(padding, '0');

            return segment;
        }


    }

}
