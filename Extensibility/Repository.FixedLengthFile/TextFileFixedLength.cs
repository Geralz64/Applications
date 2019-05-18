using Extensibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FixedLengthFile
{
    public class TextFileFixedLength<T>
    {


        /*
         What do I want to do:

        Create Fixed length file
        - Create file by using a layout already established
                -Use a layout that's already stablished
                -Write the record using the layout
                -Write the line into the file
        - Create a file by reading a layout and writing those values in the file
        - Fill the records with spaces or 0s depending on the value type

        Read fixed length 
        - Read file
        - Validate data with layout already established
              
       Read file
       -Read the file by separting the file and using an expected delmiter
              
        Create single line fixed length file
        - Create a file thats multiple records in one single line one after the other like the standards in some companies

        Read single line fixed length file
        -Divide by counting the amount of spaces between each line and then separating OR by a specific segment

        As a final note consolidate some of the code I used on the CSV classes maybe instead of a csv file I can use it to create any
        type of file by using the extension and that way I have less code to maintain. Probably create a FileManagement class 
        instead and add the CSV file classes inside this way I'll have less project libraries 


         */

        public static void CreateFile(FileInformation<T> fileInfo2, List<Layout> layout2)
        {

            //Gonna work on the read layout part of the code during the weekend in the meantime use this layout example


            //Test information************************************************************************************************************************************************************
            var layout = new List<Layout>() {

                new Layout { RecordName = "MemberID", LengthOfRecord = 10, TypeofRecord = "N" },
                new Layout { RecordName = "Name", LengthOfRecord = 20, TypeofRecord = "AN" },
                new Layout { RecordName = "LastName", LengthOfRecord = 20, TypeofRecord = "AN" },
                new Layout { RecordName = "BirthDate", LengthOfRecord = 10, TypeofRecord = "N" },
                new Layout { RecordName = "SSN", LengthOfRecord = 10, TypeofRecord = "N" }

            };


            var list = new List<string> {

                "768254873,Samuel,Carlu,19610126,12964642",
                "561752142,Ignác,Lyuba,19970630,171883451",
                "456272089,Hermes,Milena,20131118,158764459",
                "861487492,Ulric,Snorre,20191010,145211845",
                "468440653,Andrea,Diana,19560127, 170327476",
                "464570109,Lykos,Temir,19580421,127733635",
                "728413373,Dustin,Imke,19780817,129661852",
                "103634937,Andela,Ingeburg,19790814,117570340",
                "741060277,Paul,Henrike,19791011,158985165"

            };
            var fileInfo = new FileInformation<string>();
            fileInfo.Records = list;
            //****************************************************************************************************************************************************************************

            var formatedRecords = new List<string>();

            //Loop thtrough each record
            foreach (var line in fileInfo.Records)
            {

                //Split records to check each one for values
                var lineSegments = line.Split(',');
                var formatedLine = String.Empty;

                for (int i = 0; i < lineSegments.Count(); i++)
                {
                    string segment = lineSegments[i].ToString();

                    int lenghtOfRecord = layout.ElementAt(i).LengthOfRecord;
                    string typeOfRecord = layout.ElementAt(i).TypeofRecord;

                    string formatedSegment = (typeOfRecord == "AN") ? FillWithSpaces(typeOfRecord, lenghtOfRecord) : FillWithZeros(typeOfRecord, lenghtOfRecord);

                    formatedLine += formatedLine + formatedSegment;

                }

                formatedRecords.Add(formatedLine);
            }


            //Write the new line
            using (var writer = new StreamWriter(fileInfo.FileLocation + fileInfo.FileName))
            {
                foreach (var record in formatedRecords)
                {
                    writer.WriteLine(record);
                }

            }

        }



        private static string FillWithSpaces(string record, int padding)
        {

            record = record.PadLeft(padding);

            return record;

        }
        public static string FillWithZeros(string record, int padding)
        {

            record = record.PadLeft(padding, '0');

            return string.Empty;
        }


    }









    /*
     Complete tasks:

       1.  Create file (no layout)
                -Create a txt file by using a list from strings (simplest method just loop through the list and write it in a file and 
                 expect the data to already be formated with )
     => I consolidated some code so that this part is no longer needed in this class or it would be duplicated code
     




     */
}
