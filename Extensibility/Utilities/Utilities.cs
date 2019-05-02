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

        public static void BackupFile(string sourceFileName, string destinationFileName)
        {
            File.Copy(sourceFileName, destinationFileName);

        }

        public static IEnumerable<string> FilesToProcess(string path, string fileExtension)
        {

            IEnumerable<string> filesInFolder = Directory.GetFiles(path, fileExtension);


            return filesInFolder;
        }



        //Delete the file 

        //Present files with information

        public static void ShowFiles(IEnumerable<string> files )
        {

            foreach (var file in files)
            {
                Console.WriteLine(file);

            }


        }



    }
}
