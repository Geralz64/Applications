using Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.FixedLengthFile
{
    public class TextFile<T>
    {


        /*
         What do I want to do:

        Create Fixed length file
        - Create file by using a layout already established
        - Create a file by reading a layout and writing those values in the file
        - Fill the records with spaces or 0s depending on the value type

        Read fixed length 
        - Read file
        - Validate data with layout already established
       
       Create file (no layout)
       -Create a txt file by using a list from strings (simplest method just loop through the list and write it in a file and 
       expect the data to already be formated with )
       
         
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
        /*Create file(no layout)
         -Create a txt file by using a list from strings(simplest method just loop through the list and write it in a file and
         expect the data to already be formated with )     
          */

        public static void CreateFile(FileInformation<T> fileInfo)
        {



        }


    }
}
