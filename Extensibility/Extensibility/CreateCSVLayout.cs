using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensibility
{
    class CreateCSVLayout<T>
    {


        /*
         Take the read layout
         Loop thorugh the records and write the file using the layout
        
         */


        public static void CreateCSVLayoutFile(CSVFileInformation<T> cSVFileInformation, List<Layout> layout)
        {

            using (var writer = new StreamWriter(cSVFileInformation.FileLocation + cSVFileInformation.FileName))
            {

                //CREATE THE FILE USING A FOR EACH OF THE LIST OF STRINGS THAT iM SUPPOSE TO RECEIVE 


            };

        }



        //Create a line with a type of header method returning a list of strings and adding that to the csvFileInformationRecords parameter

    }
}
