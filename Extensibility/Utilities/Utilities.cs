using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Utilities
    {
        public static string LogInfoStart()
        {


            StackTrace stack = new StackTrace();

            return
                stack.GetFrame(1).GetMethod().Name.ToString();

            //Console.WriteLine($"Process {stack.GetFrame(1).ToString()} started @ {DateTime.Now}");
           
        }


        public static void LogInfoEnd()
        {

            Utilities.LogInfoStart();

            Console.WriteLine($"Process completed at {DateTime.Now}");

        }

        public static void BackupFile()
        {

           


        }


    }
}
