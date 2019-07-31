using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {


            var result = Repository.SQL.Classes.ProductionProduct.GetProducts();


            Console.WriteLine("Write down your name");

            string name = Console.ReadLine();

            Console.WriteLine("Hello there " + name);

            Console.WriteLine("How many hours of sleep did you get today?");

            int hours = Convert.ToInt32(Console.ReadLine());
                

            if(hours > 8)
            {

                Console.WriteLine("You are well rested");


            }
            else
            {
                Console.WriteLine("You need more rest");

            }

        }
    }
}
