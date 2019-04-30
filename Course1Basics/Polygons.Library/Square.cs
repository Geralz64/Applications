using System;
using System.Collections.Generic;
using System.Text;

namespace Polygons.Library
{
    public class Square : ConcreteRegularPolygon
    {

        public Square(int lenght):
            base(4,lenght)
        { }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }

    } 
}
