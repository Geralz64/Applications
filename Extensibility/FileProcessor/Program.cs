using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Extensibility;
using Repository.SQL;
using System.IO;
using System.Xml.Linq;
namespace FileProcessor
{
    class Program
    {
        static void Main()
        {


            //string FileLocation = "D:\\TestFiles\\NewMembers.csv";
            //bool HasHeader = true;
            //string Delimiter = ",";


            //ReadCSV<Member> test = new ReadCSV<Member>(FileLocation, HasHeader, Delimiter);


            //var Person = test.ReadFile();

            //foreach (var item in Person)
            //{

            //    Console.WriteLine($"Person's BirthDate: {item.BirthDate}");

            //}

            CreateXML();

            QueryXML();

        }

        private static void QueryXML()
        {
            var document = XDocument.Load("fuel.xml");

            var query =
                          from element in document.Element("Cars").Elements("Car")
                          where element.Attribute("Manufacturer").Value == "BMW"
                          select element.Attribute("Name").Value;




        }

        private static void CreateXML()
        {
            //Method 1
            //Create XML DOCUMENT
            var document = new XDocument();

            //Creates the parent
            var cars = new XElement("Cars");

            //Creates the child elements and its attributes
            var car = new XElement("Car",
                new XAttribute("Combined", "200"),
                new XAttribute("Manufacturer", "Toyota"));

            cars.Add(car);
            document.Add(cars);
            document.Save("Cars.xml");

            //Method 2 using LINQ

            /*
             
             var cars = new XElement("Cars",
                                            from record in records
                                            select new XElement("Car",
                                            new XAttribute("Combined", "200"),
                                            new XAttribute("Manufacturer", "Toyota"));
             
             
             */
        }
    }
}
