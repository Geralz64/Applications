using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

    public enum Direction : int
    {
        Right = 1,
        Left = 2,
    };

    public class FixedLengthFile
    {

        public string Record { get; set; }

        public int Length { get; set; }

        public Direction Direction { get; set; }

        //Be able to generate a file and selecting the corresponding properties from the creation

        //Generate txt files with specific length by using a layout

        //How to implement the layout

        /*Goal is to create a class that helps create any fixed lengthstxt file depending on the layout 
         * that you are providing the application
         * 
         * Input: Layout and my data(list<class object>)
         *  -Read a file that has the layout
         *      -FieldName
         *      -Type => Numeric, Alphanumeric
         *      -Length => 8 space
         *      -Fill with spaces
         *      -Fill with zeros
         *      
         * Output: formated text file
         *
         * Accept a list of generic objects
         * 
         * Read from somewhere the layout type
         * 
         * Create the file using spaces 
         *  Maybe build the space object using a method and then concatenate the object with the values from the list
         *  
         *  Read the layout or have the layout somewhere in a class, DB or an actual file
         *  
         *  2019/04/27
         * Ideas to work with
         *  Create an interface that will be implemented into the rest of the classes
         *  Create a project repository for my text files 
         *  Create a project repository for my CSV files
         *  Create a project repository for SQL probably download adventure works and play with that and also implement entity framework
         *  
         *  Then create a factory that manages all these different repositories 
         *  and use and enumerator to manage all the data from each of them 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * */



        public static string FillWithSpaces(FixedLengthFile values)
        {

            if ((int)values.Direction == 1)
            {

                values.Record = values.Record.PadRight(values.Length);
            }

            if ((int)values.Direction == 2)
            {

                values.Record = values.Record.PadLeft(values.Length);
            }


            return values.Record;
        }

        public static string FillWithZeros(FixedLengthFile values)
        {


            if ((int)values.Direction == 1)
            {

                values.Record = values.Record.PadRight(values.Length, '0');
            }

            if ((int)values.Direction == 2)
            {

                values.Record = values.Record.PadLeft(values.Length, '0');
            }


            return values.Record;
        }

    }
}
