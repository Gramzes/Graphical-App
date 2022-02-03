using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_App
{
    abstract class Light
    {
        public double Brightness { get; set; }
        public Color LightColor { get; set; }
        public Light(double brightness, Color color)
        {
            this.Brightness = brightness;
            this.LightColor = color;
        }
    }
}
