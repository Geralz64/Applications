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
            var parallelLoop = Parallel.For(0, items.Count(),(int i, ParallelLoopState loopState) =>
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


    }
}
