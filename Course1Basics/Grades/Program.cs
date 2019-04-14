using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main()
        {

            GradeBook book = new GradeBook();

            GetName(book);

            AddGrades(book);

            WriteFile(book);

            GradeStatistics stats = ChangeBookName(book);

            WriteInformation(stats);
        }

        private static void WriteInformation(GradeStatistics stats)
        {
            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult("Average Grade", stats.AverageGrade);

            WriteResult("Letter Grade", stats.LetterGrade);

            WriteResult("Description", stats.Description);
        }

        private static GradeStatistics ChangeBookName(GradeBook book)
        {
            book.NameChanged += OnNameChanged;

            book.Name = "Geraldo's Gradebook";
            GradeStatistics stats = book.ComputeStatistics();
            return stats;
        }

        private static void WriteFile(GradeBook book)
        {
            using (StreamWriter outputFile = File.CreateText("greades.txt"))
            {

                book.WriteGrades(outputFile);

            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(85);
            book.AddGrade(90);
            book.AddGrade(89.5f);
        }

        private static void GetName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a name");

                book.Name = Console.ReadLine();

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");

        }

        public static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result}");

        }


        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {

            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");

        }

    }
}
