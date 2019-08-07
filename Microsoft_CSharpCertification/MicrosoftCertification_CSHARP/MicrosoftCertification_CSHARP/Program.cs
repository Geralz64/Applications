using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MicrosoftCertification_CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {

            //Part 1.1 Parallel Invoke



            Parallel.Invoke(() => ShowOne(), () => ShowTwo(), () => ShowThree(), () => ShowFour());

            /*

            Notes:

            -You can add all the items that you want in the previous statement however you have no control

             over which one finishes first.

            -Invoke WILL wait for all of the methods to finish before continuing

             */

            //Part 1.2 Parallel For Each

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


            //Part 1.3 Parallel For

            Parallel.For(0, items.Count(), i =>

            {

                ShowItem(i.ToString());

            });

            /*Notes:

            -Parallel.For(start of the item, end of the item, name of the variable thats going to be used to pass to method => {

                Method(name of variable);

            })

             */

            //Part 1.4 Break and stop 

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

            -You can use the ParallelLoopState to control the flow of the thread 

            -Breakd => It stops new iterations but doesn't stop all current iterations from running
            -Stop => stops all iterations as soon as it's convenient 

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

            /*
            AsOrdered instructs the Parallel LINQ engine to preserve ordering, but still executes the query in parallel.
            
            This has the effect of hindering performance as the engine must carefully merge the results after parallel execution.

            AsSequential instructs the Parallel LINQ engine to execute the query sequentially, that is, not in parallel.

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

            //Part 1.11 Tasks

            var task = new Task(() => ShowOne());

            task.Start();

            task.Wait();

            //Part 1.12 task 1.2

            //Simple task creating method

            var task2 = Task.Run(() => ShowOne());

            task2.Wait();

            //Part 1.13 tasks that return values

            var task3 = Task<string>.Run(() => ReturnOne());

            Task<string> task3_2 = Task.Run(() => ReturnOne());

            task3.Wait();


            /*Notes:

            -As seen above you can also return a type from a task

             */

            //Past 1.14 Task.WaitAll and WaitAny

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

            -In the same way that WaitAll waits for all tasks to complete the WaitAny will continue when any of the

             iterations completes. However the tasks that are still running WILL continue to run

             */

            //List 1.15 ContinueWith 

            var task1_15 = Task<int>.Run(() => ShowOne());

            task1_15.ContinueWith((prevTask) => ShowObject(prevTask.ToString()));

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

            -The parent class will not complete until all the child classes have ended HOWEVER by default the child

             is independente from the parent unless you use the taskcreationoptiojns.AttachedToParent

            OR the child is returning a value that the parent is waiting for

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


            //   public static void Main()

            //    {

            //       thread1 = new Thread(ThreadProc);

            //       thread1.Name = "Thread1";

            //       thread1.Start();

            //

            //       thread2 = new Thread(ThreadProc);

            //       thread2.Name = "Thread2";

            //       thread2.Start();   

            //    }

            //

            //    private static void ThreadProc()

            //    {

            //       Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);

            //       if (Thread.CurrentThread.Name == "Thread1" && 

            //           thread2.ThreadState != ThreadState.Unstarted)

            //          thread2.Join();

            //

            //       Thread.Sleep(4000);

            //       Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);

            //       Console.WriteLine("Thread1: {0}", thread1.ThreadState);

            //       Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);

            //    }

            /*Notes

             -The caller of the join is held until the called is completed. This has to be done on the thread level

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

           

            Something the blog post noted in the comments doesn't make explicit, but I find to be very important, is that [ThreadStatic] doesn't automatically initialize things for every thread. For example, say you have this:

            [ThreadStatic]

            private static int Foo = 42;

            The first thread that uses this will see Foo initialized to 42. But subsequent threads will not. The initializer works for the first thread only. So you end up having to write code to check if it's initialized.

            ThreadLocal<T> solves that problem by letting you supply an initialization function (as Reed's blog shows) that's run before the first time the item is accessed.

            In my opinion, there is no advantage to using [ThreadStatic] instead of ThreadLocal<T>.

            Also on the other threads the variable is set to it's default values

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

                ThreadPool.QueueUserWorkItem(ShowObject, stateNumber);

                //Also ThreadPool.QueueUserWorkItem(Method that expects a parameter i, i)


                ThreadPool.QueueUserWorkItem(state => ShowObject(stateNumber));
                //Using a lambda expression


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


            //1-29 Blocking the user interface



            /*Notes:

            -Using a task to run in the background is a good way to keep the user interface from locking when performing an action

             */


            //1-30 Using a task


            /*Notes:

            -You can't just set the value of a control from inside the task it will cause an error on the display component

            Like the text property of a textbox

            -You could use the RunAsync property on the component BUT they will run asynchroniously 



                    ResultTextBlock.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>

               {

                    ResultTextBlock.Text = "Result: " + result.ToString();

               });

            */

            //1.31 Updating the UI

            /*Notes:

            -Long taking processes will block the UI of the application

            -In order to release them you need to use Async and await

            -Methods that have an async property NEED to have at least one await method

            -An await expects a method that returns a task or task<t>


             */


            //1.33 Exceptions



            try

            {

                //var text = await MethodThatReturnsTask<String>();

            }

            catch (Exception ex)

            {

            }



            /*Notes:

            -Exceptions from an await can be captured with a try catch

            */


            //1.34 Awaiting parallel tasks

            // return await Task.WaitAll(some tasks);





            //STARING OUT WITH CONCURRENT COLLECTIONS


            /*

             Types:

             BlockingCollection

             ConcurrentStack

             ConcurrentBag

             ConcurrentQueue

             ConcurrentDictionary<tkey,tvalue>


            Blocking Collection

            -when you have some tasks producing data and other tasks consuming data

            -IsCompletd is used to determine when to stop taking items from the collection

            -It returns true when the collection is empty and completedAdding has been called


            The Take can throw exceptions if

            -If the IsCompleted flag is false

            -The adding task the calls the CompleteAddding method on the collection

            -The taking task tries to take from a colletion that has been marked complete


            You can also use TryAdd and TryTake that both return bool if the process succeeded thats

            why in the example the code has a try catch

            http://dotnetpattern.com/csharp-blockingcollection

             */

            var blockingCollection = new BlockingCollection<int>(5);


            Task.Run(() =>

            {
                for (int i = 0; i < 10; i++)

                {

                    blockingCollection.Add(i);

                }

                blockingCollection.CompleteAdding();

            });



            Task.Run(() =>
            {
                while (!blockingCollection.IsCompleted)

                {
                    int v = blockingCollection.Take();
                    Console.WriteLine(v);
                }

            });






            //List 1.36 Block Cuncurrent stack


            BlockingCollection<int> blocking136 = new BlockingCollection<int>();

            //But you can also instantiate them this sway
            BlockingCollection<int> block2 = new BlockingCollection<int>(new ConcurrentStack<int>());



            /*Notes:
             * If you dont tell the Blocking collection which type of concurrent item to use THE DEFAULT IS ConcurrentQueue -> First IN FIRST OUT
             * ConcurrentStack => Last in first out 
             * 
             
             */

            //List 1.37 Concurrent Queue

            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();

            queue.Enqueue("Rob");
            queue.Enqueue("Miles");

            string requiredVariable = "";

            if (queue.TryPeek(out requiredVariable))
            {

                Console.WriteLine(requiredVariable);

            }


            if (queue.TryDequeue(out requiredVariable))
            {

                Console.WriteLine(requiredVariable);

            }


            /*Notes:
             * TryEnqueu 
             * TryDequeu
             * TryPeek - Just looks at the item
             
             */



            //List 1.38 Concurrent stack

            ConcurrentStack<string> stack = new ConcurrentStack<string>();

            stack.Push("Geraldo");
            stack.Push("Geraldo2");
            stack.Push("Geraldo3");

            var stringStack = "";

            if (stack.TryPeek(out stringStack))
            {
                Console.WriteLine(stringStack); //Going to show Geraldo3

            }

            if (stack.TryPop(out stringStack))
            {
                Console.WriteLine(stringStack); //Going to remove Geraldo3

            }

            if (stack.TryPeek(out stringStack))
            {
                Console.WriteLine(stringStack); //Going to show Geraldo2

            }


            /*Notes:
             * Push - Add
             * TryPop - Remove
             * TryPeek - Just to see the values
             * PushRange - 
             * TryPopRange - 
             
             */

            //1.39 ConcurentBag

            /*Notes:
             * Add or remove order of items isn't important
             * The tryPeek can see an item but since the items are random when you take the item it might not be the same one that you saw using the TryPeek
             * bag.Add
             * TryPeek
             * TryTake
             * 
             
             */


            var conDictionary = new ConcurrentDictionary<int, string>();


            //List 1.40 Cuncurrent Dictionary

            /*Notes:
             * Actions are performed in an atomic matter
             * The data is stored and indexed by a key
             * TryAdd
             * conDictionary[89].ToString()
             * TryUpdate(key,NewValue,OldValue)
             * AddOrUpdate
             * EXAMPLE:
             * 
             *  // Add dog with value of 5 if it does NOT exist.
                // ... Otherwise, add one to its value.
                con.AddOrUpdate("dog", 5, (k, v) => v + 1);

             */

            //LIST 1.41 Single task summing (Resource Synchronization)
            /*Notes:
             * Some examples of resources
             * How multiple resources can wait for application or other resources to finish
             * Applications being async can be slowed down by the resources available in the machine
             */

            //List 1.42 Bad task interaction

            //

            /*Notes:
             * Talk about race conditions: 
             * We don't have control over which execution takes place first
             * 
             * Implementing Locking:
             *      The actions on a dictionary that can be used my mulitple processes are called ATOMIC
             *      In other words one process cannot be interrupted the another 
             */

            //List 1.43 Locking

            //static object sharedTotalLock = new object();
            object sharedTotalLock = new object();

            lock (sharedTotalLock)
            {

                //Global variable that other tasks are accesing
            }


            /*Notes:
             * Locks:
             *      You can use locking to make sure that an action is atomic
             *      In the example when you create the object and use the Lock(Object) to stop the interruption you also removed the parallel so 
             *         its no longer running asyncroniously
             *     In order to fix it they add the values to a separete variable and the lock the shared variable to add the subtotal amount to it
             *     Now the sharedvalue is only locked for one add and the application runs a lot better
             */



            //List 1.44 Sensible Locking

            var subTotal = 0;

            subTotal = subTotal + 10;

            lock (sharedTotalLock)
            {

                //Add subtotal to global variable
            }


            /*Notes:
             * Locks should be quick to complete so not use on parts that might take a long time to respond
             * Never perform input or output operation on a lock
             * 
             * 
             */


            //1.45 Monitors

            Monitor.Enter(sharedTotalLock);
            subTotal = subTotal + subTotal;
            Monitor.Exit(sharedTotalLock);

            if (Monitor.TryEnter(sharedTotalLock))
            {

                Console.WriteLine("Entered a locks object");


            }
            else
            {

                Console.WriteLine("Object is being use by another process");
            }


            /*Notes:
             * Used to make sure that only one thread accesses the object at the same time
             * Locks release automatically on exceptions
             * Monitors dont release on exceptions you NEED to exit them 
             * A good practice for this is add the Monitor.Exit(object) on the finally part of a method
             * 
             * 
             * Locks VS Monitors
             * Locks exit upon exception != Monitors Dont you need to add the code to exit the monitor
             * Locks can't check if an object is in use != Monitors Can check it by using the Monitor.TryEnter(object)
             * 
             * 
            */



            //List 1.46 Deadlocks


            /*Notes:
             * When two tasks are waiting for each other to perform an action on a share collection
             * 
             
             */
            //Sequential locking

            /*Notes:
            * Each method gets the lock objects in turn because they are running sequentially 
            * 

            */


            //Listing 1.47 Deadlock using tasks
            /*Notes:
            * The example from the book uses tasks for this. This causes both of the tasks to run in parallel which causes a deadlock
            * Try not use locks withing one another to avoid deadlocks
            * Deadlocks are not like an infinite loop they will not consume the CPU they will just stay in memory awaiting to finish
            
            */



            //The lock object
            /*Notes:
             * Any object can become your key or your lock for the rest of your tasks
             * The scope of the object should be limited to the tasks affecting that object
             * They recommend using an object just for the lock and not other data objects
             * DO NOT USE A STRING AS A LOCK
             *
             */

            var sharedTotal = 0; //Imagine this is a global variable

            //List 1.48 Interlocked operations and Interlock total example

            Interlocked.Add(ref sharedTotal, 6);

            /*Notes:
             *A better way to achieve thread safe access to contents of a variable is to use interlocked classs
             *This can be performed in a variable
             *Increment, decrement, exchange and add?????
             *Interlocked.Add(ref lockedVariable, VariableToAdd);


             *
             */

            //Volatile Variables

            // public volatile int sharedStorage;

            /*Notes:
             * The program always looks for ways to run faster
             * You can use the volatile keyword to make the system fetch the value of the variable from memory rather than the processor
             * Operations using the volatile variable will not be optimized 
             * 
             * 
             *
             */

            //List 1.49 Cancellation tokens and how to cancel a task

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            while (!cancellationTokenSource.IsCancellationRequested)
            {

            }



            /*Notes:
             * Tasks need to be cancelled by using a cancellation token not like a thread that can be cancelled at any time
             * Using a cancellation token allows the program to tidy up and release the resources that is currently using
             * 
             */


            //List 1.50 and raising an exception when a task is cancelled, Cancel with exceptions



            if (cancellationTokenSource.IsCancellationRequested)
            {
                CancellationTokenExample(cancellationTokenSource.Token);

            }


            /*Notes:
             * You can also throw an exception sing the token if you need to throw an exception
             * In order to do so you need to access the token property from the cancellationTokenSource
             * Methods are thread safe if they can be called multiple times and still provide the right results
             * Be mindful of race conditions on global variables that remove values or update them incorrectly
             * 
             
            
             */

            //One wait to stop a variable from changing values in a method is turning it into a struct type
            //Another is to use another method to pass that value into another variable that should be our input

            //Implementing program flow
            /*While loop method
             * 
             */

            //1.53

            /*Notes:
             *  The Do while loop will execute at least ONCE before checking if the value is false REMEMBER THAT 
             *  
             *  
             */

            //1.54 for loop
            for (int i = 0; i < 10; i++)
            {

            }

            /*Notes:
             * The first iteration is always run because just like before it checks after the first run
             
             */

            //1.55 Iterate with for
            for (int i = 0; i < list.Count; i++)
            {

            }


            /*Notes:
             * Basically a for but the max is passed as the count of a list 
             */


            //1.56 For each
            foreach (var item in list)
            {

            }
            /*Notes:
            * Loop through each of the items in the list
            * You can also access the values 
            * and the var is an element of the same type as the list
            * you cant havea string of a list of ints for example it wont compile
            */


            //1.57 Going throught a list with a uppercase example


            /*Notes:
            * Just like before but this time you can use a list its the same way I always use them
            * It uses the IEnumerable interface to get the values
            * 
            */

            //1.58 Using a break statement to get out of a loop

            foreach (var item in list)
            {
                if (item == "Stop")
                {
                    break;
                }
            }


            /*Notes:
            * As mentiones above you can use a break statement to get out of a loop and move on to a next step
            */

            //1.59 Using the oontinue statement on loops

            foreach (var item in list)
            {
                if (item == "Geraldo")
                {
                    continue;
                }

                Console.WriteLine(item.ToString());
            }



            /*Notes:
            * It doesn't cause a loop to end 
            * It just stops the current iteration and then validates again if the loop should continue
            * In the example above the name Geraldo will not print BUT if there are still values in the list they will print
            * 
            */

            //1.60 if statements
            if (true)
            {
                //DO STUFF
            }

            /*Notes:
            * For real? They are using the ifs NOW after all the sync stuff? no wonder people were complaning
            * 
            */



            //1.61 Local expressions


            /*Notes:
            * Things like <, >, =, <=, >= among other examples
            * == equal to, != not equal to
            * & and
            *  | or
            *  && conditional version
            *  || conditional version 
            *  If the first statement on a conditional version is false than the second verification will not take place 
            *  These are the ones that are mostly used
            *  
            * 
            */

            //1.62 The switch statement

            switch (list.ToString())
            {
                case "1":
                    //Do something 
                    break;
                default:
                    break;

            }

            /*Notes:
            * 
            * 
            */


            //1.63 Evaluation expressions
            /*
            i++; // monadic ++ operator increment - i now 1
            i--; // monadic -- operator decrement - i now 0
                 // Postfix monadic operator - perform after value given
            Console.WriteLine(i++); // writes 0 and sets i to 1
                                    // Prefix monadic operator - perform before value given
            Console.WriteLine(++i); // writes 2 and sets i to 2
                                    // Binary operators - two operands
            i = 1 + 1; // sets i to 2
            i = 1 + 2 * 3; // sets i to 7 because * performed first
            i = (1 + 2) * 3; // sets i to 9 because + performed first
          


            i = true ? 0 : 1; // sets i to 0 because condition is true;
            */


            //1.64 -> 1.65 Events and callbacks, delegates, 

            Action test = new Action(ShowOne);

            //Check more examples about delegates


            /*Notes:
            * Events help send signals from one component to another
            * Delegates can be used to create pipelines to send signals to methods
            * You can also simplify the calling of the delate and check if the alue of it is not null: OnAlarmRaised?.Invoke();
            * 
            */

            test?.Invoke();

            //1.66 unsubscribe from a delegate


            test += ShowOne;
            test += ShowTwo;

            test -= ShowOne;


            /*Notes:
            * += to add
            * -= to remove
            * 
            */


            //1.67 Using events and delegate types

            /*Notes:
            * You can create the delete in the class as an even that doesn't require to be get or set 
            * Use the event word before the action word to do this: public event Action OnAlarmRaised = delegate {};
            * 
            */

            //1.68 Create events with build in delegate type

            /*Notes:
            * Instead of using event action you SHOULD use event eventhandler OnAlarmRaised since this is the part of the .net framework to take values
            * public event EventHandler OnAlarmRaised = delegate {};
            * And when you call the event you do it like this OnAlarmRaised(this, EventArgs.Empty);
            * When adding the delegate it MUST have the following signature private static void AlarmListener1(object sender, EventArgs e)

            
            */


            //1.69 Using event args to deliver event information 

            /*Notes:
            * You can create a class that inherits from the EventArg
            *   class AlarmEventArgs : EventArgs
            * 
            *
            */

            //1.70 Exceptions

            //This sections wasnt very clear I'm going to have to find more resources on this subject

            List<Exception> exceptionList = new List<Exception>();

            foreach (Delegate handler in test.GetInvocationList())

            {
                try
                {
                    handler.DynamicInvoke();

                }
                catch (TargetInvocationException e)
                {
                    exceptionList.Add(e);
                }


            }


            /*Notes:
            *If an error occurs the rest of the delegates will not be called
            * In order to capture the errors you can call each event handler individually and then a singles aggregate exceptions created containing all the errors
            *
            * 
            *
            */




        }

        public static void CancellationTokenExample(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }

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
