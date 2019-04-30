using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
    public abstract class AbstractRegularPolygon
    {

        public int NumberOfSides { get; set; }

        public int SideLength { get; set; }


        public AbstractRegularPolygon(int sides, int lenght)
        {

            NumberOfSides = sides;
            SideLength = lenght;

        }

        public double GetPerimeter()
        {

            return NumberOfSides * SideLength;
        }

        public abstract double GetArea();

    }
}
