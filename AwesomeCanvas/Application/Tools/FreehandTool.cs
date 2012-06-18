using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AwesomeCanvas
{
    //-------------------------------------------------------------------------
    // A class that represents free hand drawing tools like a pen or brush
    //-------------------------------------------------------------------------
    public class FreehandTool : DrawingTool 
    {
        // Constructor
        public FreehandTool(BaseApp baseApp) : base(baseApp)
        { 
            
        }

        //---------------------------------------------------------------------
        // The draw command
        public override void Draw(Layer layer, Point start, Point end = new Point())
        {
            DrawLine(layer, start, end);
        }

        // Calculate the line and step through
        public void DrawLine(Layer layer, Point start, Point end = new Point())
        {
            // Create a line vector
            Vector2D vector = new Vector2D(start.X - end.X, start.Y - end.Y);

            // Create the point to draw at
            PointF drawPoint = new Point(end.X, end.Y);

            // Get the amount to step each time
            PointF step = vector.GetNormalisedVector();

            // Find the length of the line
            double length = vector.GetMagnitude();

            // For each step along the line...
            for (int i = 0; i < length; i++)
            {
                // Draw a pixel
                DrawStep(layer, new Point((int)drawPoint.X, (int)drawPoint.Y));
                drawPoint.X += step.X;
                drawPoint.Y += step.Y;
            }
        }

        // Draw on the actual canvas
        public virtual void DrawStep(Layer layer, System.Drawing.Point point)
        { 
            
        }
    }
}
