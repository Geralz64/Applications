
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public class DataManagement
    {

        #region Methods
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
