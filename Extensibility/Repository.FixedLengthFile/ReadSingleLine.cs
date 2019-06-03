using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Repository.FixedLengthFile
{
    public static class ReadSingleLine<T>
    {

        public static string ReadFile(FileInformation<T> fileInformation)
        {

            var records = new List<string>();

            foreach (var line in File.ReadLines(fileInformation.FileLocation + fileInformation.FileName))
            {
                records.Add(line);
            }

            return records.First();
        }



        public static List<string> SplitSingleLine(string fileInfo, List<Layout> layoutInfo)
        {

            var recordLength = 0;

            foreach (var recordInfo in layoutInfo)
            {

                recordLength += recordInfo.LengthOfRecord;

            }

            var totalCharactersInFile = fileInfo.Count();

            var amountOfRecords = totalCharactersInFile / recordLength;

            var start = 0;
            var list = new List<string>();

            for (int i = 0; i < amountOfRecords; i++)
            {

                list.Add(fileInfo.Substring(start, recordLength));

                start += recordLength;
            }

            return new List<string>();
        }



        //Check if function is going to be used in the right way 
        public static List<string> GetRecordInformationByPosition(FileInformation<T> fileInformation, List<Layout> layout)
        {

            var records = fileInformation.Records;

            var segments = new List<string>();

            foreach (var line in records)
            {
                int start = 0;
                int length = 0;

                foreach (var lenghtOfRecord in layout)
                {

                    length = lenghtOfRecord.LengthOfRecord;
                    string segment = line.ToString().Substring(start, length);

                    segments.Add(segment);

                    start = length;
                }
            }

            return segments;

        }





    }
}
