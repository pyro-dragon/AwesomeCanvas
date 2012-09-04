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
        public FreehandTool(ToolRunner pController)
            : base(pController)
        { 
            
        }

        public override void Down(int pX, int pY, float pPressure, Picture pPicture, Layer pLayer, object pOptions) 
        {
            base.Down(pX, pY, pPressure, pPicture, pLayer, pOptions);
            DrawStep(pLayer, new Point(pX, pY), pPressure);
        }

        public override void Move(int pX, int pY, float pPressure) 
        {
            base.Move(pX, pY, pPressure);
            Point position = new Point(pX, pY);
            if (isDown)
                DrawLine(m_layer, m_lastPosition, position, m_lastPressure, pPressure);
            m_lastPosition = position;
            m_lastPressure = pPressure;
        }

        // Calculate the line and step through
        public void DrawLine(Layer layer, Point start, Point end, float pStartPressure, float pEndPressure)
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
                float pressure = MathExt.Lerp(pStartPressure, pEndPressure, quota);
                DrawStep(layer, position.ToPointRounded(), pressure);

            }
        }

        // Draw on the actual canvas
        protected virtual void DrawStep(Layer layer, System.Drawing.Point point, float pPressure)
        { 
            
        }

        protected virtual void GetSize() { }
    }
}
