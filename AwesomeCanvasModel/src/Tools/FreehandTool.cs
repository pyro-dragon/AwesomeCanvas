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

        public override void Move(int pX, int pY, int pPressure, Picture pPicture, Layer pLayer) {
            base.Move(pX, pY, pPressure, pPicture, pLayer);
            Point position = new Point(pX, pY);
            if (isDown)
                DrawLine(pLayer, m_lastPosition, position, m_lastPressure, pPressure);
            m_lastPosition = position;
            m_lastPressure = pPressure;
        }

        // Calculate the line and step through
        public void DrawLine(Layer layer, Point start, Point end, int pStartPressure, int pEndPressure)
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
                int pressure = MathExt.RoundToInt(MathExt.Lerp(pStartPressure, pEndPressure, quota));
                DrawStep(layer, position.ToPointRounded(), pressure);

            }
        }

        // Draw on the actual canvas
        protected virtual void DrawStep(Layer layer, System.Drawing.Point point, int pPressure)
        { 
            
        }

        protected virtual void GetSize() { }
    }
}
