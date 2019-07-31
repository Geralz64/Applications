using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.TestData
{
    public class ProductTestData
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Inventory { get; set; }

        public int ExpirationDate { get; set; }

        public string Price { get; set; }

        public string PriorityLevel { get; set; }

        public enum Level
        {
            VeryHigh = 5,

            High = 4,

            Medium = 3,

            Low = 2,

            VeryLow = 1
        }


        public static List<ProductTestData> GetProductTestData()
        {
            var list = new List<ProductTestData> {

                new ProductTestData {ProductID = 100, Name = "Monitor",     Inventory = 10, ExpirationDate = 20390101, Price = "500.00",    PriorityLevel = Level.High.ToString() },
                new ProductTestData {ProductID = 101, Name = "Computer",    Inventory = 15, ExpirationDate = 20580301, Price = "1000.00",   PriorityLevel = Level.VeryHigh.ToString() },
                new ProductTestData {ProductID = 102, Name = "Mouse",       Inventory = 86, ExpirationDate = 20991201, Price = "10.00",     PriorityLevel = Level.VeryLow.ToString() },
                new ProductTestData {ProductID = 103, Name = "Fan",         Inventory = 45, ExpirationDate = 20691101, Price = "5.00",      PriorityLevel = Level.VeryLow.ToString() },
                new ProductTestData {ProductID = 104, Name = "Pen",         Inventory = 86, ExpirationDate = 20790801, Price = "1.00",      PriorityLevel = Level.VeryLow.ToString() },
                new ProductTestData {ProductID = 105, Name = "Charger",     Inventory = 54, ExpirationDate = 20690701, Price = "12.00",     PriorityLevel = Level.Medium.ToString() },
                new ProductTestData {ProductID = 106, Name = "Cup",         Inventory = 12, ExpirationDate = 20390901, Price = "10.00",     PriorityLevel = Level.Medium.ToString() },
                new ProductTestData {ProductID = 107, Name = "Cable",       Inventory = 36, ExpirationDate = 20290401, Price = "12.00",     PriorityLevel = Level.High.ToString() },
                new ProductTestData {ProductID = 108, Name = "HeadPhones",  Inventory = 12, ExpirationDate = 20790101, Price = "88.00",     PriorityLevel = Level.High.ToString() },
                new ProductTestData {ProductID = 109, Name = "Table",       Inventory = 98, ExpirationDate = 20990201, Price = "800.00",    PriorityLevel = Level.VeryHigh.ToString() },
                new ProductTestData {ProductID = 110, Name = "Chair",       Inventory = 47, ExpirationDate = 20290301, Price = "150.00",    PriorityLevel = Level.VeryHigh.ToString() },
                new ProductTestData {ProductID = 111, Name = "MousePad",    Inventory = 99, ExpirationDate = 20201201, Price = "55.00",     PriorityLevel = Level.Low.ToString() }
                };

            return list;
        }




    }
}
