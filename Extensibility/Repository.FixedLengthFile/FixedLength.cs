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

        public static bool CreateFile(FileInformation<T> fileInfo, List<Layout> layout)
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

                    formatedLine +=  formatedSegment;

                }

                formatedRecords.Add(formatedLine);
            }

            using (var writer = new StreamWriter(fileInfo.FileLocation + fileInfo.FileName))
            {
                foreach (var record in formatedRecords)
                {
                    writer.WriteLine(record);
                }
                writer.Close();

            }

            bool isValid = File.Exists(fileInfo.FileLocation + fileInfo.FileName);

            return isValid;
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

    public class TestFileInformation {

        public string ID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int BirthDate { get; set; }

        public int MyProperty { get; set; }




    }







    /*
     Complete tasks:

       1.  Create file (no layout)
                -Create a txt file by using a list from strings (simplest method just loop through the list and write it in a file and 
                 expect the data to already be formated with )
     => I consolidated some code so that this part is no longer needed in this class or it would be duplicated code
     

        Create Fixed length file
        - Create file by using a layout already established
                -Use a layout that's already stablished
                -Write the record using the layout
                -Write the line into the file

        - Create a file by reading a layout and writing those values in the file
        - Fill the records with spaces or 0s depending on the value type



     */
}
