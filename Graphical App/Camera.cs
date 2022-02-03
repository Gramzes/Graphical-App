using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_App
{
    class Camera
    {
        public Coordinates ViewPoint;
        
        double canvasWidth;
        public double CanvasWidth
        {
            get => canvasWidth;
            set
            {
                if (value > 0) { canvasWidth = value; }
                else
                {
                    throw new Exception("The width of the canvas must be greater than zero.");
                }
            }
        }
        double canvasHeight;
        public double CanvasHeight
        {
            get => canvasHeight;
            set
            {
                if (value > 0) { canvasHeight = value; }
                else
                {
                    throw new Exception("The height of the canvas must be greater than zero.");
                }
            }
        }
        double canvasDistance;
        public double CanvasDistance
        {
            get => canvasDistance;
            set
            {
                if (value > 0) { canvasDistance = value; }
                else
                {
                    throw new Exception("The distance to the canvas must be greater than zero.");
                }
            }
        }

        public Camera(Coordinates ViewPoint, double canvasWidth, double canvasHeight, double canvasDistance)
        {
            this.ViewPoint = ViewPoint;
            this.CanvasHeight = canvasHeight;
            this.CanvasWidth = canvasWidth;
            this.CanvasDistance = canvasDistance;
        }

        public Coordinates PixelCoordOnCanvas(double x, double y, double width, double height) => new Coordinates(x * (canvasWidth / width), y * (canvasHeight / height), canvasDistance);
    }
}
