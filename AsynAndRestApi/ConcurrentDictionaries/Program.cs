using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConcurrentDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            //StandardDictionary();

            var stock = new ConcurrentDictionary<string, int>();


            //Adding examples
            stock.TryAdd("Poke Incubators", 4);
            stock.TryAdd("Pokeballs", 10);
            stock.TryAdd("PokeEggs", 6);
            stock.TryAdd("GameCartriges", 25);

            //Adding examples with success capturing
            Console.WriteLine("Number of items in stock: " + stock.Count);
            stock.TryAdd("Stickers", 5);
            bool success = stock.TryAdd("Shirts", 5);
            Console.WriteLine("Added new item correctly? ");
            Console.WriteLine(success);

            success = stock.TryAdd("Shirts", 5);
            Console.WriteLine("Added new item correctly? ");
            Console.WriteLine(success);



            Console.WriteLine("Number of items in stock: " + stock.Count);

            //Remove example with success capturing
            int jStickersValue;
            success = stock.TryRemove("Stickers",out jStickersValue);
            if(success)
                Console.WriteLine("Value was removed: " + jStickersValue);


            //Update example with success capturing
            success = stock.TryUpdate("GameCartriges", 30, 25);
            if (success)
                Console.WriteLine("Value was updated: " + stock["GameCartriges"]);


            //Update example with success capturing
            success = stock.TryUpdate("GameCartriges", 40, 25);
            if (!success)
                Console.WriteLine("Value was NOT updated: " + stock["GameCartriges"]);


            //AddOrUpdate example
            int tempStock = stock.AddOrUpdate("GameCartriges", 1, (key, oldValue) => oldValue + 1);
            Console.WriteLine("Value was NOT updated: " + tempStock);

            stock.GetOrAdd("GameCartriges", 10);

            //GetOrAdd example
            Console.WriteLine($"stock[GameCartriges] = {stock.GetOrAdd("GameCartriges", 12)}");


            Console.WriteLine("Inventory available:");

            foreach (var item in stock)
            {

                Console.WriteLine(item.Key + " " + item.Value);

            }

        }

        private static void StandardDictionary()
        {
            var stock = new Dictionary<string, int>()
            {
                {"Poke Incubators", 4 },
                {"Pokeballs", 10 },
                {"PokeEggs", 6 },
                {"Game Cartriges", 25 }
            };

            Console.WriteLine("Number of items in stock: " + stock.Count);

            stock.Add("Stickers", 5);
            stock.Add("Shirts", 5);

            stock.Remove("Stickers");

            Console.WriteLine("Inventory available:");

            foreach (var item in stock)
            {

                Console.WriteLine(item.Key + " " + item.Value);

            }
        }


        public static void QueueTestMethod()
        {

            var queue = new Queue<string>();

            queue.Enqueue("Stickers");
            queue.Enqueue("Pokeball");
            queue.Enqueue("Shirts");
            queue.Enqueue("Games");

            Console.WriteLine(queue.Count);


            string firstItem = queue.Dequeue();
            Console.WriteLine(firstItem);

            string item = queue.Peek();
            Console.WriteLine(item);

        }


        public static void ConcurrentQueueTestMethod()
        {

            var queue = new ConcurrentQueue<string>();

            queue.Enqueue("Stickers");
            queue.Enqueue("Pokeball");
            queue.Enqueue("Shirts");
            queue.Enqueue("Games");

            Console.WriteLine(queue.Count);


            string firstItem = "";

            bool success = queue.TryDequeue(out firstItem);
            if (success)
            {
                Console.WriteLine(firstItem);
            }
            else
            {

                Console.WriteLine("No item found ");

            }
            string item = "";

            success = queue.TryPeek(out item);
            if (success)
            {
                Console.WriteLine(item);

            } else
            {
                Console.WriteLine("No item found ");

            }
        }



    }
}
