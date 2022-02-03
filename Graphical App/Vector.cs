using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_App
{
    struct Vector
    {
        public Coordinates Coord { get; private set; }
        public Vector(Coordinates vector)
        {
            Coord= vector;
        }

        static public Vector operator +(Vector vector1, Vector vector2) => new Vector(vector1.Coord+vector2.Coord);
        static public Vector operator -(Vector vector) => new Vector(vector.Coord*(-1));
        static public Vector operator -(Vector vector1, Vector vector2) => vector1 + (-vector2);
        static public Vector operator *(double a, Vector vector2) => new Vector(vector2.Coord * a);
        static public Vector operator *(Vector vector2, double a) => new Vector(vector2.Coord * a);
        static public Vector operator /(Vector vector2, double a) => new Vector(vector2.Coord/a);

        static public double ScalarProduct(Vector vector1, Vector vector2)
        {
            return vector1.Coord.X * vector2.Coord.X + vector1.Coord.Y * vector2.Coord.Y + vector1.Coord.Z * vector2.Coord.Z;
        }

        public double Lenght() => Math.Sqrt(ScalarProduct(this, this));
    }
}
