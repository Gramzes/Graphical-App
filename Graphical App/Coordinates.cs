using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_App
{
    struct Coordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Coordinates(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        static public Coordinates operator +(Coordinates coord1, Coordinates coord2)
        {
            double x = coord1.X + coord2.X;
            double y = coord1.Y + coord2.Y;
            double z = coord1.Z + coord2.Z;
            return new Coordinates(x, y, z);
        }

        static public Coordinates operator -(Coordinates coord) => new Coordinates(-coord.X, -coord.Y, -coord.Z);
        static public Coordinates operator -(Coordinates coord1, Coordinates coord2) => coord1+(-coord2);
        static public Coordinates operator *(double a, Coordinates coord) => new Coordinates(coord.X*a, coord.Y*a, coord.Z*a);
        static public Coordinates operator *(Coordinates coord, double a) => a*coord;
        static public Coordinates operator /(Coordinates coord, double a) => coord*(1/a);
    }
}
