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
    class FreehandTool : DrawingTool 
    {
        // Constructor
        public FreehandTool()
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
            Vector2D vector = new Vector2D(start.X - end.X, start.Y - end.Y);
        }

        // Draw on the actual canvas
        public virtual void DrawStep(Layer layer, System.Drawing.Point point)
        { 
            
        }
    }
}
