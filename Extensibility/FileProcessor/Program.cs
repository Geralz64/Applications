using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Extensibility;
using Repository.SQL;
using System.IO;

namespace FileProcessor
{
    class Program
    {
        static void Main()
        {


            string FileLocation = "D:\\TestFiles\\NewMembers.csv";
            bool HasHeader = true;
            string Delimiter = ",";
           

            ReadCSV<Member> test = new ReadCSV<Member>(FileLocation, HasHeader, Delimiter);


            var Person = test.ReadFile();

            foreach (var item in Person)
            {

                Console.WriteLine($"Person's BirthDate: {item.BirthDate}");

            }


        }
    }
}
