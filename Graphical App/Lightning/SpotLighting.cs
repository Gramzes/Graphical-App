using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_App
{
    class SpotLighting : Light
    {
        public Coordinates coordinates;
        public SpotLighting(double brightness, Coordinates coordinates, System.Drawing.Color color) : base(brightness, color) 
        {
            this.coordinates = coordinates;
        }
    }
}
