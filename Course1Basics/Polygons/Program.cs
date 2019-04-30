using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polygons.Library;

namespace Polygons
{
    class Program
    {
        static void Main(string[] args)
        {

            var square = new Square(5);
            //DisplayPolygon("Square", square);

            var triangle = new Triangle(5);
            //DisplayPolygon("Triangle", square);

            var Octagon = new Octagon(5);
            //DisplayPolygon("Octagon", square);


            Console.Read();





        }
    }
}
