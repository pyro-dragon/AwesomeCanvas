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

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public Layer(int width, int height, string name)
        {
            Name = name;
            Opacity = 1.0f;
            Visible = true;
            History = new History();
            m_bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            m_area = new Rectangle(0, 0, width, height);
        }

        //---------------------------------------------------------------------
        // Render the layers contents
        //---------------------------------------------------------------------
        public void Draw(Graphics g, Rectangle pOutputRect, Rectangle pSampleRect )
        {
            pSampleRect.X = pSampleRect.X - Offset.X;
            pSampleRect.Y = pSampleRect.Y - Offset.Y;
            g.DrawImage(m_bitmap,
                        pOutputRect,
                        pSampleRect,
                        GraphicsUnit.Pixel
                        );
        }

        public Bitmap GetBitmap() { return m_bitmap; }
        public Rectangle GetArea() { return m_area; }
    }
}
