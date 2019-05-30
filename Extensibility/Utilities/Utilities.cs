using Extensibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Utilities
    {

        #region LogInformation

        public static string LogInfoStart()
        {

            StackTrace stack = new StackTrace();

            return stack.GetFrame(1).GetMethod().Name.ToString();

        }

        public static void LogInfoEnd()
        {

            Utilities.LogInfoStart();

            Console.WriteLine($"Process completed at {DateTime.Now}");

        }

        #endregion

        #region PresentInformation

        public static void ShowFiles(IEnumerable<string> files)
        {

            foreach (var file in files)
            {
                Console.WriteLine(file);

            }
        }

        //public static void ShowFilesWithInfo(List<FileInformation<T>> files)
        //{

        //    foreach (var file in files)
        //    {

        //        Console.Write($"Name: {file.FileName} Count: {file.RecordCount}");

        //    }

        //}

        #endregion

        #region FileManagement
        public static IEnumerable<string> FilesToProcess(string path, string fileExtension)
        {

            IEnumerable<string> filesInFolder = Directory.GetFiles(path, "*." + fileExtension);


            return filesInFolder;
        }

        public static void BackupFile(string sourceFileName, string destinationFileName)
        {
            File.Copy(sourceFileName, destinationFileName);

        }

        #endregion

        #region DataManagement
        public static string FillWithSpaces(string segment, int padding)
        {

            segment = segment.PadLeft(padding);

            return segment;
        }

        public static string FillWithZeros(string segment, int padding)
        {

            segment = segment.PadLeft(padding, '0');

            return segment;
        }

        public static List<string> FormatRecords(List<string> records, List<Layout> layout)
        {
            var formatedRecords = new List<string>();

            foreach (var line in records)
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

        public static string RemoveSpecialCharacters(string item)
        {

            item = item.Replace("ñ", "n");
            item = item.Replace("Ñ", "N");
            item = item.Replace("'", "");
            item = item.Replace(",", "");

            return item;


        }

        public static List<string> GetRecordInformationByPosition(FileInformation<string> fileInformation, List<Layout> layout)
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

        #endregion



    }
}
