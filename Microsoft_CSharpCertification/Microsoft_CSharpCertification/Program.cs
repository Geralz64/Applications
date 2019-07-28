using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft_CSharpCertification
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part 1.1
            Parallel.Invoke(() => ShowOne(), () => ShowTwo(), () => ShowThree(), () => ShowFour());

            /*
            Notes:
            -You can add all the items that you want in the previous statement however you have no control
             over which one finishes first.

            -Invoke WILL wait for all of the methods to finish before continuing

             */


            //Part 1.2
            var items = Enumerable.Range(0, 500);

            var list = new List<string>() {

                "Test1", "Test2", "Test3"
            };

            Parallel.ForEach(items, item =>
            {

                ShowItem(item.ToString());

            });

            /*Notes:
            -The Parallel.ForEach will run the process for all the items in that are passed down to it
            -You have no control over which item is run first

            */

            //Part 1.3

            Parallel.For(0, items.Count(), i =>
             {

                 ShowItem(i.ToString());

             });


            /*Notes:
            -Parallel.For(start of the item, end of the item, name of the variable thats going to be used to pass to method => {

                Method(name of variable);
            })
             */

            //Part 1.4
            Console.WriteLine("Part 1.4");
            var parallelLoop = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
              {

                  if (i == 200)
                  {
                      loopState.Stop();
                  }

                  ShowItem(i.ToString());


              });

            //Also the break and stop methods of the parallelLoopState method

            var parallelLoopBreak = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {

                if (i == 200)
                {
                    loopState.Break();
                }

                ShowItem(i.ToString());


            });

            //Break will exit the loop after all the iterations previous to the current one complete
            var parallelLoopStop = Parallel.For(0, items.Count(), (int i, ParallelLoopState loopState) =>
            {

                if (i == 200)
                {
                    loopState.Stop();
                }

                ShowItem(i.ToString());


            });

            //Stop will exit the loop as soon as its convenient for the program

            /*Notes:
            -You can use the ParallelLoopResult to control the flow of the thread 
            -This will stop the thread from running more iterations BUT it will not stop the ones that are currently running
             */

            //Part 1.5
            var newlist = from a in list.AsParallel()
                          where a.Contains("A")
                          select a;

            foreach (var item in newlist)
            {
                Console.WriteLine(item);

            }


            /*Notes:
            -As seen in the example above you can also use the the threading library to query objects
            -However this alone will not keep the order of the results you will need other extension methods for this
            -The system decides if using the threading library will speed up the process if it doesn't then the system
            will run the query normally 
             */



            //Part 1.6

            var list1_6 = from a in list.AsParallel().
                          WithDegreeOfParallelism(4).
                          WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                          select a;

            /*Notes:
            -In the example above you force the parallelism on the query even if you dont care what resources it uses

             */


            //Part 1.7

            var list1_7 = from a in list.AsParallel().
                          AsOrdered()
                          select a;


            /*Notes:
            -The query above orders the results but IT CAN slow down the process
            -Parallel may also remove the ordering of a complex query

            -AsSequencial => identify the parts of a query that must be sequentially executed. It executes the query in order
            -AsOrdered => returns the sorted result but does not necessarily run the query in order

             */


            //Part 1.8
            var list1_8 = (from a in list.AsParallel()
                           orderby (a.Substring(1, 1))
                           select new
                           {

                               Name = a.Substring(1, 2)

                           }).AsSequential().Take(4);

            /*Notes:

            -If the above query was ran without the AsSequential the take(4) could bring a different value than what is expected
            -However if you add it that means that the list is ordered first and then you take the 4 results that you want

            */

            //Part 1.9
            list1_7.ForAll(a => Console.WriteLine(a.Substring(1, 2)));

            /*Notes:
            -By using the ForAll that means that the output written WILL NOT reflect the input since you are once again
             reordering the values
             */

            //Part 1.10

            try
            {
                var list1_10 = from a in list.AsParallel()
                               where CheckValue(a.Substring(1, 2))
                               select a;
            }
            catch (AggregateException ex)
            {

                Console.WriteLine(ex);

            }


            /*Notes:
            -Queries using PLINQ can throw exceptions and its in good practice to capture them that means that you need
             a way to capture those AggregateExceptions
             */


            //Part 1.11
            var task = new Task(() => ShowOne());

            task.Start();
            task.Wait();

            //Part 1.12
            //Simple task creating method

            var task2 = Task.Run(() => ShowOne());

            task2.Wait();

            //Part 1.13

            var task3 = Task<string>.Run(() => ReturnOne());

            Task<string> task3_2 = Task.Run(() => ReturnOne());

            task3.Wait();

            /*Notes:
            -As seen above you can also return a type from a task

             */


            //Past 1.14

            var taskArray = new Task[10];

            for (int i = 0; i < 10; i++)
            {

                int id = i;

                taskArray[i] = Task.Run(() => ShowOne());


            }

            Task.WaitAll(taskArray);
            /*Notes:
            -In the example above you initiate a task array an populate the values in each one
             then you use the Task.WaitAll method to run all the values inside the array
            -In the same wayt that WaitAll waits for all tasks to complete the WaitAny will continue when any of the
             iterations complets. However the tasks that are still running WILL continue to run
             */


            //List 1.15
            var task1_15 = Task.Run(() => ShowOne());

            task.ContinueWith((prevTask) => ShowTwo());


            /*Notes:
            -Continuation tasks help pass the signal that one task has finished to another creating a pipeline of signals
             between each task. That way you have more control over which task is executed. 
             */


            //List 1.16 Continuation options

            var task1_16 = Task.Run(() => ShowOne());

            task.ContinueWith((prevTask) => ShowTwo(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) => ShowThree(), TaskContinuationOptions.OnlyOnFaulted);



            /*Notes:
             -You can pass more parameters to the task method to help capture errors among other values. Like only run on completion or
              only run when the previous task has an error
             */

            //List1.17 Child tasks

            var parent = Task.Factory.StartNew(() =>
            {

                for (int i = 0; i < 10; i++)
                {

                    int taskNo = i;

                    Task.Factory.StartNew((x) => ShowItem(x.ToString())
                                                 , taskNo
                                                 , TaskCreationOptions.AttachedToParent
                                                 );

                }

            });

            parent.Wait();

            /*Notes:
            -The parent class will not complete until all the child classes have ended
            -You can also use the option TaskCreationOptions.DenyChildAttach to that the parent and child are independent
            -If you use task.run instead of factory the childs will be created with the DenychildAttach option set


             */

            //Threads and threadpools


            /*Notes:
            -Threads are of a lower level of abstraction
            -Task is an item of work
            -Thread is a process running in the system
            -Threads are foreground operations
            -Tasks are background operations
            -Tasks can be terminated before they complete since they run in the background
            -An infite loop thread will lock the application forever


            -Threads CAN be assigned a priority property while tasks cannot
            -You can share variables between threads you should use global variables
            -Threads can't use the continuation property THEY CAN HOWERVER use the join to allow one thread to pause while
             another continues
            -You have to deal with the exceptions with the code inside of the thread they are not like tasks that can
             handle the exceptions inside the tasks themselves

             */


            //1-18 Creating threads

            var thread = new Thread(ShowOne);
            thread.Start();

            //1-19 Old style of starting threads

            var ts = new ThreadStart(ShowOne);

            var thread119 = new Thread(ts);

            thread.Start();


            //1-20 Threads and lambda expressions

            var thread20 = new Thread(() =>
            {

                Console.WriteLine("Test");
                ShowOne();
            });

            Console.WriteLine("Test2");

            thread20.Start();

            /*Notes:
            - In the example above the tes2 will print before test1 because before the thread is called the main
             will start the next part of the code

             */

            //1-21 Parameterized thread start

            ParameterizedThreadStart ps = new ParameterizedThreadStart(ShowObject);

            var thread21 = new Thread(ps);

            thread21.Start(100);



            /*Notes
             - You can pass a parameter to a thread by using the ParameterizedThreadStart
             -Pass a delegate that expects an object and then start the thread and pass that value in the start
             */

            //1-22 Passing a parameter but as a lambda expression

            var thread22 = new Thread((info) =>
            {

                ShowObject(info);

            });

            thread22.Start(100);



            /*Notes
             -Same as above but instead you pass the value as part of a lambda expression
             */


            //1-23 how to abort a thread

            var thread23 = new Thread(() =>
            {

                while (true)
                {
                    Console.WriteLine("100");

                }

            });


            thread23.Start();
            thread23.Abort();


            /*Notes
             -If you abort a thread all the values and resources assigned to that thread stay there
              so its better to end the thread with a shared flag variable
             */


            //1-24

            var tick = true; //Since this is a shared variable it should be outside the main 

            var thread24 = new Thread(() =>
            {
                while (tick)
                {
                    Console.WriteLine("Tick");

                }

            });

            thread24.Start();
            tick = false;


            /*Notes
             -By using the flag the thread ends and all the resources are released

             */


            //1-25 Thread syncronization and using the join instead of the continue

            var thread25 = new Thread(() =>
            {
                ShowOne();

            });


            thread25.Start();
            thread25.Join();

            /*Notes
             -The caller of the join is held until the called is completed

            IMPORTANT
            -If you want each thread to have it's own copy of a variable when you are using a shared variable
            then use the ThreadStatic attribute on the shared variable

             */


            //1-26 Thread static and thread local variables


            /*
               [ThreadStatic]
               static int value = 10;

                */

            ThreadLocal<Random> rand = new ThreadLocal<Random>(() =>
            {
                return new Random(2);

            });


            /*Notes:
            -Threadstatic attribute will create a new variable for each thread
            -Instanciation a ThreadLocal will create a new variable that will be used for all threads in this case the
             random number is created and used using the the same seed for all threads
             */


            //1-27 Thread execution context




            /*Notes:
            - Just some examples of thread information that you can display like thread level, current culture among others
             */


            //1-28 Thread pools

            for (int i = 0; i < 50; i++)
            {

                int stateNumber = i;

                ThreadPool.QueueUserWorkItem(state => ShowObject(stateNumber));


            }


            /*Notes:
            -Pools are collection of threads
            -It stores a collection of reusable thread objects
            -Limits the number of threads that can be ran at the same time
            -The others are place in  queue


            -Do not use if the threads are going to be idle for a long time
            -You can't set priority in a thread pool
            -All threads in a pool have background priority 
            -Local thread variables are not cleared so DON'T USE THEM in a threadpool 
             */




        }

        public static void ShowObject(object obj)
        {


            Console.WriteLine(obj.ToString());
        }


        public static string ReturnOne()
        {

            return "1";

        }

        public static void ShowOne()
        {
            Console.WriteLine("Number: 1");
            Thread.Sleep(2000);

        }


        public static void ShowTwo()
        {
            Console.WriteLine("Number: 2");
            Thread.Sleep(2000);

        }

        public static void ShowThree()
        {
            Console.WriteLine("Number: 3");
            Thread.Sleep(2000);

        }

        public static void ShowFour()
        {
            Console.WriteLine("Number: 4");
            Thread.Sleep(2000);

        }

        public static void ShowItem(string i)
        {

            Console.WriteLine(i);

        }


        public static bool CheckValue(string value)
        {

            var flag = true;

            if (value != "1")
            {

                throw new ArgumentException(value);

            }
            else
            { flag = false; }

            return flag;

        }

    }
}
