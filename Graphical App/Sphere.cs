using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_App
{
    class Sphere
    {
        public Coordinates CenterCoord;
        private int radius;
        public Color Color;
        public int Radius 
        { 
            get => radius;
            set
            {
                if (value > 0) { radius = value; }
                else { throw new Exception("The radius must be greater than zero."); }
            }
        }
        public Sphere(Coordinates center, int radius, Color color)
        {
            CenterCoord = center;
            Radius = radius;
            Color = color;
        }
    }
}
