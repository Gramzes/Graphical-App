using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_App
{
    class AmbientLighting : Light
    {
        public AmbientLighting(double brightness, System.Drawing.Color color) : base(brightness, color) { }
    }
}
