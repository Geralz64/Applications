using System;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * The purpose of this class is to practice creating and understanding the usage of delegates without having to 
             * make changes to my other libraries
             */

            /*Delegates are good to run bundles or lists of tasks that take the same values 
             * In the next example image that you press a button and you have to call a method that 
             * notifies the users, generates a file and runs a program and all of these use the same parameters as their input
             */

            //Running the delegate with only one call of a method

            var del1 = new PerformWork(RunProgram);
            var del2 = new PerformWork(GenerateFile);
            var del3 = new PerformWork(NotifyUsers);


            var del4 = new Work();

            del1(DateTime.Now);

            //Running the delegate by adding multiple methods to the same pipeline

            del1 += del2 + del3;

            del1(DateTime.Now);

        }

        public delegate void PerformWork(DateTime timeStamp);

        public static void RunProgram(DateTime timeStamp)
        {
            Console.WriteLine($"Work type: {"Run program"}, Time ran {timeStamp}");
        }

        public static void GenerateFile(DateTime timeStamp)
        {
            Console.WriteLine($"Work type: Generate file, Time ran {timeStamp}");
        }

        public static void NotifyUsers(DateTime timeStamp)
        {
            Console.WriteLine($"Work type: Notify users, Time ran {timeStamp}");
        }

    }
}
