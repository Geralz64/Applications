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
            IGradeTracker book = CreateGradeBook();

            GetName(book);

            AddGrades(book);

            WriteFile(book);

            WriteInformation(book);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteInformation(IGradeTracker book)
        {

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }


            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Highest Grade", stats.HighestGrade);
            WriteResult("Lowest Grade", stats.LowestGrade);
            WriteResult("Average Grade", stats.AverageGrade);

            WriteResult("Letter Grade", stats.LetterGrade);

            WriteResult("Description", stats.Description);
        }

        private static GradeStatistics ChangeBookName(IGradeTracker book)
        {
            book.NameChanged += OnNameChanged;

            book.Name = "Geraldo's Gradebook";
            GradeStatistics stats = book.ComputeStatistics();
            return stats;
        }

        private static void WriteFile(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("greades.txt"))
            {

                book.WriteGrades(outputFile);

            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(85);
            book.AddGrade(90);
            book.AddGrade(89.5f);
        }

        private static void GetName(IGradeTracker book)
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
