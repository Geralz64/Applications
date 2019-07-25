using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingApp
{
    class Program
    {



        static void Main(string[] args)
        {

            var inventory = new Dictionary<string, int>() {

                {"Pokeballs", 10},
                {"Incubators", 5},
                {"Swords", 2},
                {"PolygonCharmander", 12},
                {"PolygonSquirtle",15},
                {"PolygonBulbasaur", 8}

            };

            var test1 = false;
            if (test1)
            {
                //Test 1 Normal dictionary
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 1:");

                NormalDictionaryTest(inventory);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 1 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");
            }

            var test2 = false;

            if (test2)
            {
                //Test 2 Run multiple methods with parallel programming and returning values 
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 2:");

                TaskAndWaitAllTest(inventory);

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 2 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");

            }

            var test3 = false;

            if (test3)
            {
                //Test 3 Using the concurrent dictionary
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 3:");

                ConcurrentDictionaryTest();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 3 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");


            }


            var test4 = false;
            if (test4)
            {
                //Test 4 Using the concurrent bag
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 4:");

                ConcurrentBagTest();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 4 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");

            }

            var test5 = false;
            if (test5)
            {
                //Test 5 Using the concurrent stack
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 5:");

                ConcurrentStackTest();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 5 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");

            }


            var test6 = true;
            if (test6)
            {
                //Test 5 Using the concurrent stack
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 6:");

                ConcurrentQueue();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 6 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");

            }

        }

        private static void ConcurrentQueue()
        {
            ConcurrentQueue<string> queue = new ConcurrentQueue<string>();

            queue.Enqueue("Pokeballs");
            queue.Enqueue("Incubators");
            queue.Enqueue("Swords");
            queue.Enqueue("PolygonCharmander");
            queue.Enqueue("PolygonSquirtle");
            queue.Enqueue("PolygonBulbasaur");

            Console.WriteLine($"Items in queue: {queue.Count}");
            Console.WriteLine("");

            string item;

            //item is take from the queue
            var isValid = false;
            isValid = queue.TryDequeue(out item);
            if (isValid)
                Console.WriteLine($"Item in queue: {item}");

            Console.WriteLine("");
            //item is only viewed from the queue
            isValid = queue.TryPeek(out item);
            if (isValid)
                Console.WriteLine($"Item in queue: {item}");

            Console.WriteLine("");


            Console.WriteLine($"View values from concurrent queue: {queue.Count}");
            foreach (var prop in queue)
            {

                Console.WriteLine(prop);

            }


        }

        private static void ConcurrentStackTest()
        {
            //Concurrent stack works a lot like ConcurrentBag however this one is a last in first out method
            Console.WriteLine("Create new ConcurrentStack with a collection as an overloard...");
            //Adding items through a collection
            var list = new List<string>();
            list.Add("Pokeballs");
            list.Add("Incubators");
            list.Add("Swords");
            list.Add("PolygonCharmander");
            list.Add("PolygonSquirtle");
            list.Add("PolygonBulbasaur");

            ConcurrentStack<string> stackWithCollection = new ConcurrentStack<string>(list);

            Console.WriteLine($"Items in stack: {stackWithCollection.Count}");
            Console.WriteLine("");

            Console.WriteLine("Create new ConcurrentStack and add values through the push method...");
            ConcurrentStack<string> stackWithPush = new ConcurrentStack<string>();
            //Addint items through the push method of the stack object
            stackWithPush.Push("Push Pokeballs");
            stackWithPush.Push("Push Incubators");
            stackWithPush.Push("Push Swords");
            stackWithPush.Push("Push PolygonCharmander");
            stackWithPush.Push("Push PolygonSquirtle");
            stackWithPush.Push("Push PolygonBulbasaur");

            Console.WriteLine($"Items in stack: {stackWithPush.Count}");
            Console.WriteLine("");

            Console.WriteLine($"View values from concurrent stack: {stackWithPush.Count}");

            foreach (var item in stackWithPush)
            {
                Console.WriteLine(item);
            }

        }

        public static void ConcurrentBagTest()
        {

            ConcurrentBag<string> bag = new ConcurrentBag<string>();


            //Test 4.1 Adding items to concurrent bag and normal bag calls
            var test1 = false;
            if (test1)
            {
                bag.Add("Pokeballs");
                bag.Add("Incubators");
                bag.Add("Swords");
                bag.Add("PolygonCharmander");
                bag.Add("PolygonBulbasaur");
                bag.Add("PolygonSquirtle");


                Console.WriteLine("Items in concurrent bag:");

                foreach (var stringItem in bag)
                {
                    Console.WriteLine(stringItem);

                }

                Console.WriteLine("");

                Console.WriteLine("Total items in bag: " + bag.Count);


                string item;
                bool isValid = bag.TryPeek(out item);
                if (isValid)
                    Console.WriteLine("Random item from the bag is: " + item);

                Console.WriteLine("");

                string item2;
                isValid = bag.TryTake(out item2);
                if (isValid)
                    Console.WriteLine("Random item TAKEN from the bag is: " + item2);


                string item3;
                isValid = bag.TryTake(out item3);
                if (isValid)
                    Console.WriteLine("Random item TAKEN from the bag is: " + item3);

                string item4;
                isValid = bag.TryTake(out item4);
                if (isValid)
                    Console.WriteLine("Random item TAKEN from the bag is: " + item4);


                Console.WriteLine("");

            }

            var test2 = false;
            if (test2)
            {
                //Test 4.2 Taking all the items from the bag. This is almost identical as my last test but it gets the job done
                bag.Clear();

                Task t1 = Task.Factory.StartNew(() =>
                {
                    for (int i = 1; i < 10; ++i)
                    {
                        bag.Add(i.ToString());
                        Thread.Sleep(200);
                    }
                });

                Task t2 = Task.Factory.StartNew(() =>
                {
                    int i = 0;
                    while (i != 4)
                    {
                        foreach (var item in bag)
                        {
                            Console.WriteLine(i + "-" + item);
                            Thread.Sleep(200);
                        }
                        i++;
                        Thread.Sleep(200);
                    }

                });

                Task.WaitAll(t1, t2);


            }

            //Test 4.3 using a concurrent bag and a AutoResetEvent to release a single thread at a time

            var test3 = false;
            if (test3)
            {
                ConcurrentBag<string> newbag = new ConcurrentBag<string>();
                AutoResetEvent autoEvent1 = new AutoResetEvent(false);

                Task t1 = Task.Run(() =>
                {
                    for (int i = 1; i <= 5; ++i)
                    {
                        newbag.Add("Item added in first thread:" + i.ToString());
                    }

                    //Wait for the signal from the second thread to tell this one to finish
                    autoEvent1.WaitOne();

                    while (!newbag.IsEmpty)
                    {
                        string item;
                        if (newbag.TryTake(out item))
                        {
                            Console.WriteLine(item);
                        }
                    }
                });


                Task t2 = Task.Run(() =>
                {
                    for (int i = 6; i <= 10; ++i)
                    {
                        newbag.Add("Item added in second thread:" + i.ToString());
                    }

                    //Signal the first thread that it may continue
                    autoEvent1.Set();
                });

                t1.Wait();

            }

            /*Test 4.4 Not about concurrent bag but I wanted to try the ManualResetEvent to 
            set all of the threads free at the same time with a simple example */
            var test4 = true;
            if (test4)
            {
                ManualResetEvent mobj = new ManualResetEvent(false);

                Task t1 = Task.Run(() =>
                {

                    Console.WriteLine("Start test part 1...");
                    mobj.WaitOne();
                    Console.WriteLine("Finishing test part 1...");
                });


                Task t2 = Task.Run(() =>
                {

                    Console.WriteLine("Start test part 2...");
                    mobj.WaitOne();
                    Console.WriteLine("Finishing test part 2...");
                });

                Task t3 = Task.Run(() =>
                {

                    Console.WriteLine("Start test part 3...");
                    mobj.WaitOne();
                    Console.WriteLine("Finishing test part 3...");
                });

                Task t4 = Task.Run(() =>
                {

                    Console.WriteLine("Start test part 4...");
                    mobj.WaitOne();
                    Console.WriteLine("Finishing test part 4...");
                });

                Console.WriteLine("Press enter to release threads:");
                Console.ReadLine();

                mobj.Set();
                Console.WriteLine("Threads released...");

            }




        }

        public static void ConcurrentDictionaryTest()
        {

            var runTest = false;

            if (runTest)
            {

                //Test 3.1 Adding multiple values to the dictionary
                ConcurrentDictionary<string, int> dictionary = new ConcurrentDictionary<string, int>();

                dictionary.TryAdd("Pokeballs", 10);
                dictionary.TryAdd("Incubators", 5);
                dictionary.TryAdd("Swords", 2);
                dictionary.TryAdd("PolygonCharmander", 12);
                dictionary.TryAdd("PolygonSquirtle", 15);
                dictionary.TryAdd("PolygonBulbasaur", 8);


                Task<int> addTask = Task.Run<int>(() => { var add = Add(dictionary["Pokeballs"], 78); return add; });

                Task<int> substractTask = Task.Run<int>(() => { var substract = Substract(dictionary["Incubators"], 7); return substract; });

                Task<int> multiplyTask = Task.Run<int>(() => { var multiply = Multiply(dictionary["Swords"], 15); return multiply; });

                Task<int> divideTask = Task.Run<int>(() => { var divide = Divide(dictionary["PolygonCharmander"], 2); return divide; });

                Task<int> addAndSubtractTask = Task.Run<int>(() => { var addAndSubtract = AddAndSubtract(dictionary["PolygonSquirtle"], 27); return addAndSubtract; });

                Task<int> addAndMultiplyTask = Task.Run<int>(() => { var addAndMultiply = AddAndMultiply(dictionary["PolygonBulbasaur"], 7); return addAndMultiply; });

                Task.WaitAll(addTask, substractTask, multiplyTask, divideTask, addAndSubtractTask, addAndMultiplyTask);

                //Update the data to the ConcurrentDictionary
                dictionary.AddOrUpdate("Pokeballs", 10, (key, oldValue) => oldValue + addTask.Result);
                dictionary.AddOrUpdate("Incubators", 5, (key, oldValue) => oldValue + substractTask.Result);
                dictionary.AddOrUpdate("Swords", 2, (key, oldValue) => oldValue + multiplyTask.Result);
                dictionary.AddOrUpdate("PolygonCharmander", 12, (key, oldValue) => oldValue + divideTask.Result);
                dictionary.AddOrUpdate("PolygonSquirtle", 15, (key, oldValue) => oldValue + addAndSubtractTask.Result);
                dictionary.AddOrUpdate("PolygonBulbasaur", 8, (key, oldValue) => oldValue + addAndMultiplyTask.Result);

                //Test 3.2 Run multple tasks that access the same field in the ConcurrentDictionary

                Task addTask2 = Task.Run(() =>
                {

                    var add = Add(dictionary["Pokeballs"], 1);
                    dictionary.AddOrUpdate("Pokeballs", 10, (key, oldValue) => oldValue + add);

                });

                Task substractTask2 = Task.Run(() =>
                {

                    var substract = Substract(dictionary["Pokeballs"], 1);
                    dictionary.AddOrUpdate("Pokeballs", 10, (key, oldValue) => oldValue + substract);

                });

                Task multiplyTask2 = Task.Run(() =>
                {

                    var multiply = Multiply(dictionary["Pokeballs"], 15);
                    dictionary.AddOrUpdate("Pokeballs", 10, (key, oldValue) => oldValue + multiply);

                });


                Task addAndSubtractTask2 = Task.Run(() =>
                {

                    var addAndSubtract = AddAndSubtract(dictionary["Pokeballs"], 27);
                    dictionary.AddOrUpdate("Pokeballs", 10, (key, oldValue) => oldValue + addAndSubtract);

                });

                Task addAndMultiplyTask2 = Task.Run(() =>
                {

                    var addAndMultiply = AddAndMultiply(dictionary["Pokeballs"], 7);
                    dictionary.AddOrUpdate("Pokeballs", 10, (key, oldValue) => oldValue + addAndMultiply);

                });



                Task.WaitAll(addTask2, substractTask2, multiplyTask2, addAndSubtractTask2, addAndMultiplyTask2);

                Console.WriteLine(dictionary["Pokeballs"]);
            }

            var runTest2 = true;
            if (runTest2)
            {
                //Test 3.2 Do the same thing but with a loop that takes longer. Add new values to the dictionary while you present all of them in two new tasks 
                //That way you add items while you enumerate them and using the library you should not get an error 

                ConcurrentDictionary<string, string> dictionary2 = new ConcurrentDictionary<string, string>();

                Task task1 = Task.Run(() =>
                {
                    for (int i = 0; i < 100; ++i)
                    {
                        dictionary2.TryAdd(i.ToString(), i.ToString());
                        Thread.Sleep(100);
                    }
                });

                Task task2 = Task.Run(() =>
                {
                    Thread.Sleep(300);
                    foreach (var item in dictionary2)
                    {
                        Console.WriteLine(item.Key + "-" + item.Value);
                        Thread.Sleep(150);
                    }
                });

                Task.WaitAll(task1, task2);

            }

        }


        public static void NormalDictionaryTest(Dictionary<string, int> inventory)
        {


            var add = Add(143, 78);
            inventory["Pokeballs"] = add;

            var substract = Substract(23, 7);
            inventory["Incubators"] = substract;

            var multiply = Multiply(1, 15);
            inventory["Swords"] = multiply;

            var divide = Divide(10, 2);
            inventory["PolygonCharmander"] = divide;

            var addAndSubtract = AddAndSubtract(74, 27);
            inventory["PolygonSquirtle"] = addAndSubtract;

            var addAndMultiply = AddAndMultiply(10, 7);
            inventory["PolygonBulbasaur"] = addAndMultiply;

            Console.WriteLine("Current inventory:");

            foreach (var item in inventory)
            {

                Console.WriteLine(item);

            }

        }

        public static void TaskAndWaitAllTest(Dictionary<string, int> inventory)
        {


            Task<int> addTask = Task.Run<int>(() => { var add = Add(143, 78); return add; });

            Task<int> substractTask = Task.Run<int>(() => { var substract = Substract(23, 7); return substract; });

            Task<int> multiplyTask = Task.Run<int>(() => { var multiply = Multiply(1, 15); return multiply; });

            Task<int> divideTask = Task.Run<int>(() => { var divide = Divide(10, 2); return divide; });

            Task<int> addAndSubtractTask = Task.Run<int>(() => { var addAndSubtract = AddAndSubtract(74, 27); return addAndSubtract; });

            Task<int> addAndMultiplyTask = Task.Run<int>(() => { var addAndMultiply = AddAndMultiply(10, 7); return addAndMultiply; });

            Task.WaitAll(addTask, substractTask, multiplyTask, divideTask, addAndSubtractTask, addAndMultiplyTask);

            inventory["Pokeballs"] = addTask.Result;
            inventory["Incubators"] = substractTask.Result;
            inventory["Swords"] = multiplyTask.Result;
            inventory["PolygonCharmander"] = divideTask.Result;
            inventory["PolygonSquirtle"] = addAndSubtractTask.Result;
            inventory["PolygonBulbasaur"] = addAndMultiplyTask.Result;

            Console.WriteLine("Current inventory:");

            foreach (var item in inventory)
            {

                Console.WriteLine(item);

            }

        }


        public static int Add(int value1, int value2)
        {

            var value3 = value1 + value2;

            Thread.Sleep(2000);

            return value3;

        }

        public static int Substract(int value1, int value2)
        {

            var value3 = value1 - value2;

            Thread.Sleep(2000);

            return value3;

        }

        public static int Multiply(int value1, int value2)
        {

            var value3 = value1 * value2;

            Thread.Sleep(3000);

            return value3;

        }

        public static int Divide(int value1, int value2)
        {

            var value3 = value1 / value2;


            Thread.Sleep(4000);

            return value3;

        }


        public static int AddAndSubtract(int value1, int value2)
        {

            var value3 = (value1 + value2) - 1;

            Thread.Sleep(6000);

            return value3;

        }

        public static int AddAndMultiply(int value1, int value2)
        {

            var value3 = (value1 + value2) * (value1 + value2);

            Thread.Sleep(2000);

            return value3;

        }


    }
}
