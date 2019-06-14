using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ConcurrentCollectioins
{
    class Program
    {
        static void Main(string[] args)
        {
            var cuntOrders = new ConcurrentQueue<string>();

            Task task1 = Task.Run(() => ShowOrderInfo(cuntOrders, "Geraldo"));
            Task task2 = Task.Run(() => ShowOrderInfo(cuntOrders, "Sam"));

            Task.WaitAll(task1, task2);

            foreach (var item in cuntOrders)
            {

                Console.WriteLine(item);

            }

            Console.WriteLine("Hello World!");
        }


        public static void ShowOrderInfo(ConcurrentQueue<string> cuntOrders, string orderName)
        {

            for (int i = 0; i < 5; i++)
            {

                cuntOrders.Enqueue(orderName + " " + i.ToString());

            }

        }

        


    }
}
