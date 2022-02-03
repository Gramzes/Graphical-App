using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Graphical_App
{
    class GraphicsProcessor
    {
        Form1 form;
        Graphics graphics;
        Camera camera;
        Bitmap bitmap;
        Color backgroundColor = Color.White;

        Sphere[] spheres =
        {
            //new Sphere(new Coordinates(0,-1,3), 1, Color.FromArgb(255, 255, 255)),
            new Sphere(new Coordinates(0,0,4), 1, Color.FromArgb(255,255,255))
            //new Sphere(new Coordinates(-1,0,3), 1, Color.FromArgb(0,255,0))
        };
        Light[] lights =
        {
            //new AmbientLighting(0.2, Color.FromArgb(200, 130, 70)),
            //new DirectLighting(0.5,new Vector(new Coordinates(-1,-1,-1)), Color.FromArgb(45, 255, 160)),
            new SpotLighting(1, new Coordinates(0, 0, 0), Color.FromArgb(0, 255, 0)),
            new SpotLighting(1, new Coordinates(0, 0, 0), Color.FromArgb(255, 0, 0)),
        };

        public GraphicsProcessor(Form1 form, Graphics graphics)
        {
            this.form = form;
            this.graphics = graphics;
            camera = new Camera(new Coordinates(0,0,0), 1, 1, 1);
            bitmap = new Bitmap(1000, 1000);   
        }
        public void Render()
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            for (int x = -width/2; x <width/2; x++)
            {
                for (int y = -height/2; y <height/2; y++)
                {
                    Coordinates PixelCoord = camera.PixelCoordOnCanvas(x, y, bitmap.Width, bitmap.Height);
                    Color PixelColor = TraceRay(camera.ViewPoint, PixelCoord, 1, double.MaxValue);
                    bitmap.SetPixel(x + width / 2, y + height / 2, PixelColor);
                }
            }
            bitmap.Save(@"C:\Temp\a.png", System.Drawing.Imaging.ImageFormat.Png);
        }
        public Color TraceRay(Coordinates firstPoint, Coordinates secondPoint, double min_value, double max_value)
        {
            double closest_t = double.MaxValue;
            Sphere closest_sphere = null;

            foreach(Sphere sphere in spheres)
            {
                double t1, t2;
                IntersectRaySphere(firstPoint, secondPoint, sphere, out t1, out t2);
                if (t1>=min_value && t1<=max_value && t1 < closest_t)
                {
                    closest_t = t1;
                    closest_sphere = sphere;
                }
                if (t2 >= min_value && t2 <= max_value && t2 < closest_t)
                {
                    closest_t = t2;
                    closest_sphere = sphere;
                }
            }
            if (closest_sphere == null) return backgroundColor;
            Coordinates SpherePoint = firstPoint + closest_t * (secondPoint - firstPoint);
            Vector N = new Vector(SpherePoint - closest_sphere.CenterCoord);
            N = N / N.Lenght();
            var lightCoef = LightHandler(SpherePoint, N);
            Color renderColor = ColorMultiplication(closest_sphere.Color, lightCoef);
            return renderColor;
        }

        private Color ColorMultiplication(Color color, (double, double, double) a)
        {
            int A = color.A;
            int R = (int)(color.R * a.Item1);
            R = R>255 ? 255:R;
            int G = (int)(color.G * a.Item2);
            G = G > 255 ? 255 : G;
            int B = (int)(color.B * a.Item3);
            B = B > 255 ? 255 : B;
            return Color.FromArgb(A, R, G, B);
        }

        public void IntersectRaySphere(Coordinates firstPoint, Coordinates secondPoint, Sphere sphere, out double t1, out double t2)
        {
            Coordinates C = sphere.CenterCoord;
            double r = sphere.Radius;
            Vector OC = new Vector(firstPoint - C);
            Vector D = new Vector(secondPoint - firstPoint);

            double k1 = Vector.ScalarProduct(D, D);
            double k2 = 2*Vector.ScalarProduct(OC, D);
            double k3 = Vector.ScalarProduct(OC, OC) - r*r;

            double discriminant = k2 * k2 - 4 * k1 * k3;
            if (discriminant < 0)
            {
                t1 = double.MaxValue;
                t2 = double.MaxValue;
            }
            else 
            {
                t1 = (-k2 + Math.Sqrt(discriminant)) / (2 * k1);
                t2 = (-k2 - Math.Sqrt(discriminant)) / (2 * k1);
            }
        }

        public (double, double, double) LightHandler(Coordinates spherePoint, Vector N)
        {
            double lightIntensityR = 0;
            double lightIntensityG = 0;
            double lightIntensityB = 0;
            Vector L = new Vector();
            foreach (Light light in lights)
            {
                if (light is AmbientLighting)
                {
                    lightIntensityR += light.Brightness* light.LightColor.R/255;
                    lightIntensityG += light.Brightness * light.LightColor.G / 255;
                    lightIntensityB += light.Brightness * light.LightColor.B / 255;
                    continue;
                }
                else if (light is DirectLighting)
                {
                    L = (light as DirectLighting).LightDirect;
                }
                else
                {
                    L = new Vector((light as SpotLighting).coordinates - spherePoint);
                }

                double n_dot_l = Vector.ScalarProduct(N, L);
                if (n_dot_l > 0)
                {
                    lightIntensityR += light.Brightness * n_dot_l / (N.Lenght() * L.Lenght()) * light.LightColor.R / 255;
                    lightIntensityG += light.Brightness * n_dot_l / (N.Lenght() * L.Lenght()) * light.LightColor.G / 255;
                    lightIntensityB += light.Brightness * n_dot_l / (N.Lenght() * L.Lenght()) * light.LightColor.B / 255;
                }
            }
            return (lightIntensityR, lightIntensityG, lightIntensityB);
        } 
    }
}
