using System;
using DelegatesAndEvents;
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

            del1(DateTime.Now);

            //Running the delegate by adding multiple methods to the same pipeline

            del1 += del2 + del3;

            del1(DateTime.Now);

            /*************************************************************************************************************************/

            var work = new Worker();

            //work.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(worker_WorkPerformed);
            work.WorkCompleted += new EventHandler(worker_Completed);

            work.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)            
            {

                Console.WriteLine(e.ToString());

            };

            work.WorkPerformed += (s, e) => Console.WriteLine(DateTime.Now);


            work.WorkPerformed += (s, e) =>
            {
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("New Line");
            };

            work.DoSomething(DateTime.Now);


            BusinessRules addDelete = (x, y) => x + y;
            BusinessRules mult = (x, y) => x * y;

            //With this you can pass the business rules thorught a delegate to a method
            var processData = new ProcessData();
            processData.Process(2, 3, addDelete);
            processData.Process(2, 3, mult);


            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultAction = (x, y) => Console.WriteLine(x * y);


            var data = new ProcessData();


            data.ProcessAction(2, 3, myAction);


            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultDel = (x, y) => x * y;
            data.ProcessFunc(3, 2, funcAddDel);

            /*****************************************************************************************/

            var sources = new IReferenceDataSource[] { new SqlReferenceDataSource(), new XmlReferenceDataSource(), new ApiReferenceDataSource() };

            sources.GetAllItemsByCode("Blue");

            var obj1 = int.MaxValue;

            Console.WriteLine("obj1" + obj1.ToJsonString());

            var obj2 = DateTime.Now;

            Console.WriteLine("obj2" + obj2.ToJsonString());

        }

        static void worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {

            Console.WriteLine(e.ToString());
        }

        static void worker_Completed(object sender, EventArgs e)
        {

            Console.WriteLine(e.ToString());
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
