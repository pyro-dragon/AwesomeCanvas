using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AwesomeCanvas.Application.Controller;
namespace AwesomeCanvas
{
    //---------------------------------------------------------------------
    // A tool for performing brush strokes with
    //---------------------------------------------------------------------
    public class BrushTool : FreehandTool
    {
        protected Color m_colour = Color.Aqua;
        public BrushTool(Controller pController)
            : base(pController)
        {
            size = 18;
            m_colour = Color.Maroon;
        }

        //---------------------------------------------------------------------
        // Render the alterations to the layer
        //---------------------------------------------------------------------
        public override void DrawStep(Layer layer, Point position)
        {
            // Set the tool size rect to the locate on of the point to be painted
            Point centre = new Point((position.X - m_halfSize),
                                     (position.Y - m_halfSize));
            m_toolArea.Location = centre;

            // Get the area to be painted
            Rectangle areaToPaint = new Rectangle();
            areaToPaint = Rectangle.Intersect(layer.GetArea(), m_toolArea);

            // Get bitmap data to draw to
            Bitmap bmp = layer.GetBitmap();

            // Lock the bitmap memory area
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Set up iteration of unsafe byte data
            int stride = data.Stride;

            // Do shit with pointers
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                // Check this is not a null area
                if (!areaToPaint.IsEmpty)
                {
                    // Go through the draw area and set the pixels as they should be
                    int len = m_toolArea.Height * m_toolArea.Width;
                    for (int i = 0; i < len; i++ )
                    {
                        int x = i % m_toolArea.Width;
                        int y = i/m_toolArea.Width; 
                        // Check if the pixel is inside the circle
                        if ((((m_halfSize - x) * (m_halfSize - x)) + ((m_halfSize - y) * (m_halfSize - y)) <= m_halfSquared) && layer.GetArea().Contains(x + m_toolArea.X, y + m_toolArea.Y))
                        {
                            // Set the pixel RGB channels individually
                            ptr[((x + m_toolArea.X) * 4) + (y + m_toolArea.Y) * stride] = m_colour.B;
                            ptr[((x + m_toolArea.X) * 4) + (y + m_toolArea.Y) * stride + 1] = m_colour.G;
                            ptr[((x + m_toolArea.X) * 4) + (y + m_toolArea.Y) * stride + 2] = m_colour.R;
                            ptr[((x + m_toolArea.X) * 4) + (y + m_toolArea.Y) * stride + 3] = m_colour.A;
                        }
                    }
                }
            }

            // Unlock the bitmap memory area
            bmp.UnlockBits(data);
        }
    }
}
