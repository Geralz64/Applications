using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
    public class ConcreteRegularPolygon
    {
        public int NumberOfSides { get; set; }

        public int SideLength { get; set; }

        public ConcreteRegularPolygon(int sides, int lenght)
        {

            NumberOfSides = sides;
            SideLength = lenght;
        
        }


        public double GetPerimeter()
        {

            return NumberOfSides * SideLength;
        }


        public virtual double GetArea()
        {

            throw new NotImplementedException();

        }


    }
}
