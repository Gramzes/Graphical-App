using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_App
{
    class DirectLighting : Light
    {
        public Vector LightDirect { get; set; }
        public DirectLighting(double brightness, Vector lightDirect, System.Drawing.Color color) : base(brightness, color)
        {
            this.LightDirect = lightDirect;
        }
    }
}
