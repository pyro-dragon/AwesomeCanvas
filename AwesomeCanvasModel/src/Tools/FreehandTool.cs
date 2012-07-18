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
    public class FreehandTool : Tool 
    {
        // Constructor
        public FreehandTool(Controller pController)
            : base(pController)
        { 
            
        }

        public override void Move(int pX, int pY, int pSize, Picture pPicture, Layer pLayer) {
            base.Move(pX, pY, pSize, pPicture, pLayer);
            Point position = new Point(pX, pY);
            if (isDown)
                DrawLine(pLayer, m_lastPosition, position, m_lastSize, pSize);
            m_lastPosition = position;
            m_lastSize = pSize;
        }

        // Calculate the line and step through
        public void DrawLine(Layer layer, Point start, Point end, int pStartSize, int pEndSize)
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
                float quota =  (float)i / length;
                PointF position = PointFExt.Lerp(fStart, fEnd,quota);
                int size = MathExt.RoundToInt(MathExt.Lerp(pStartSize, pEndSize, quota));
                DrawStep(layer, position.ToPointRounded(), size);

            }
        }

        // Draw on the actual canvas
        public virtual void DrawStep(Layer layer, System.Drawing.Point point, int pSize)
        { 
            
        }
    }
}
