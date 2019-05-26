using System;
using ExtensionMethods.Classes;
namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {


            var date = new DateTime(1920, 12, 31);
            var newDate = date.ToLegacyFormat();

            Console.WriteLine(newDate);

            var name = "My Name";
            var newName = name.ToLegacyFormat();

            Console.WriteLine(newName);
            Console.Read();
        }
    }
}
