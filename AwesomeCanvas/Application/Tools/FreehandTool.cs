using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AwesomeCanvas.Application.Math;
namespace AwesomeCanvas
{
    //-------------------------------------------------------------------------
    // A class that represents free hand drawing tools like a pen or brush
    //-------------------------------------------------------------------------
    public class FreehandTool : Tool 
    {
        // Constructor
        public FreehandTool()
        { 
            
        }

        public override void Move(int pX, int pY, Picture pPicture, Layer pLayer) {
            base.Move(pX, pY, pPicture, pLayer);
            m_postion = new Point(pX, pY);
            if (isDown) 
                DrawLine(pLayer, m_lastPosition, m_postion);
            m_lastPosition = m_postion;
        }

        // Calculate the line and step through
        public void DrawLine(Layer layer, Point start, Point end = new Point())
        {
            // Create a line vector
            PointF fStart = PointFExt.FromPoint(start);
            PointF fEnd = PointFExt.FromPoint(end);
            PointF delta = fEnd.Subtract(fStart);

            // Create the point to draw at
            PointF drawPoint = new Point(end.X, end.Y);

            // Find the length of the line
            float length = delta.Length();

            // For each step along the line...
            for (int i = 0; i < length; i++)
            {
                // Draw a pixel
                DrawStep(layer, PointFExt.Lerp(fStart, fEnd, (float)i/length).ToPointRounded());

            }
        }

        // Draw on the actual canvas
        public virtual void DrawStep(Layer layer, System.Drawing.Point point)
        { 
            
        }
    }
}
