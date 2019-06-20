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

            var test1 = true;
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

            var test2 = true;

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

            var test3 = true;

            if (test3)
            {
                //Test 3 Using the concurrent dictionary
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine($"Test 3:");


                ConcurrentDictionaryTest();



                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                Console.WriteLine($"Test 2 Execution Time Total: {elapsedMs}");
                Console.WriteLine("");


            }




        }

        public static void ConcurrentDictionaryTest()
        {

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

            //Test 2.1 Run multple tasks that access the same field in the ConcurrentDictionary

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

            Task.WaitAll(addTask2);

            Console.WriteLine(dictionary["Pokeballs"]);

            //Test 2.2 Do the same thing but with a loop that takes longer. Add new values to the dictionary while you present all of them in two new tasks 
            //That way you add items while you enumerate them and using the library you should not get an error 




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
