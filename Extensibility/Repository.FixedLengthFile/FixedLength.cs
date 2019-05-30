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
