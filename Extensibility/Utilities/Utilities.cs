using Extensibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public static void BackupFile(string sourceFileName, string destinationFileName)
        {
            File.Copy(sourceFileName, destinationFileName);

        }



        public static void ShowFiles(IEnumerable<string> files)
        {

            foreach (var file in files)
            {
                Console.WriteLine(file);

            }
        }

        #endregion

        #region FileManagement
        public static IEnumerable<string> FilesToProcess(string path, string fileExtension)
        {

            IEnumerable<string> filesInFolder = Directory.GetFiles(path, fileExtension);


            return filesInFolder;
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

        #endregion
    }
}
