using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AwesomeCanvas
{
    //-------------------------------------------------------------------------
    // The class representing the layer in a picture.
    //-------------------------------------------------------------------------
    public class Layer
    {
        // Member variables
        public History History { get; private set; }
        public string Name { get; set; }
        public float Opacity { get; set; }
        public bool Visible { get; set; }
        public Point Offset { get; set; }
        Bitmap m_bitmap;
        Rectangle m_area;
        public string ID { get; private set; }
        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public Layer(int pWidth, int pHeight, string pName, string pID)
        {
            ID = pID;
            Name = pName;
            Opacity = 1.0f;
            Visible = true;
            History = new History();
            m_bitmap = new Bitmap(pWidth, pHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            m_area = new Rectangle(0, 0, pWidth, pHeight);
        }

        //---------------------------------------------------------------------
        // Render the layers contents
        //---------------------------------------------------------------------
        public void Draw(Graphics pGraphics, Rectangle pOutputRect, Rectangle pSampleRect )
        {
            Draw(pGraphics, pOutputRect, pSampleRect, false);
        }
        //---------------------------------------------------------------------
        // Render the layers contents
        //---------------------------------------------------------------------
        public void Draw(Graphics pGraphics, Rectangle pOutputRect, Rectangle pSampleRect, bool smooth) {
            // Set the draw rectagle to draw
            pSampleRect.X = pSampleRect.X - Offset.X;
            pSampleRect.Y = pSampleRect.Y - Offset.Y;

            // Set the interpolation mode - this will ensure we have crisp lines when zooming in
            if(smooth)
                pGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            else
                pGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            // Issue the draw command
            pGraphics.DrawImage(
                m_bitmap,
                pOutputRect,
                pSampleRect,
                GraphicsUnit.Pixel
            );
        }

        public Bitmap GetBitmap() { return m_bitmap; }
        public Rectangle GetArea() { return m_area; }
    }
}
