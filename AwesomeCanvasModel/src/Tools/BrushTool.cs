using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace AwesomeCanvas
{
    //---------------------------------------------------------------------
    // A tool for performing brush strokes with
    //---------------------------------------------------------------------
    public class BrushTool : FreehandTool
    {
        //options for BrushTool
        public class Options : ToolOptions 
        {
            public bool pressureSensitive;
            public Color color;
            public int size;
        }

        public BrushTool(Controller pController)
            : base(pController)
        {
        }
        
        //cover up base.options with a casted version
        protected new Options options {
            get { return base.options as Options; }
        }
        
        //SetOptions is called on every Tool.Down
        //I haven't figured a better way for converting anon json objects.
        protected override void SetOptions(Newtonsoft.Json.Linq.JContainer o) {
            base.options = o.ToObject<Options>();
        }

        //---------------------------------------------------------------------
        // Render the alterations to the layer
        //---------------------------------------------------------------------
        protected override void DrawStep(Layer layer, Point position, int pPressure)
        {
            int size = options.size;
            int halfSize = size / 2;
            Rectangle toolArea = new Rectangle(0, 0, size, size);
            int halfSizeSquared = halfSize * halfSize;
            Color color = options.color;

            // Set the tool size rect to the locate on of the point to be painted
            Point centre = new Point((position.X - halfSize),
                                     (position.Y - halfSize));
            toolArea.Location = centre;

            // Get the area to be painted
            Rectangle areaToPaint = new Rectangle();
            areaToPaint = Rectangle.Intersect(layer.GetArea(), toolArea);

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
                    int len = toolArea.Height * toolArea.Width;
                    for (int i = 0; i < len; i++ )
                    {
                        int x = i % toolArea.Width;
                        int y = i/toolArea.Width; 
                        // Check if the pixel is inside the circle
                        if ((((halfSize - x) * (halfSize - x)) + ((halfSize - y) * (halfSize - y)) <= halfSizeSquared) && layer.GetArea().Contains(x + toolArea.X, y + toolArea.Y))
                        {
                            // Set the pixel RGB channels individually
                            ptr[((x + toolArea.X) * 4) + (y + toolArea.Y) * stride] = color.B;
                            ptr[((x + toolArea.X) * 4) + (y + toolArea.Y) * stride + 1] = color.G;
                            ptr[((x + toolArea.X) * 4) + (y + toolArea.Y) * stride + 2] = color.R;
                            ptr[((x + toolArea.X) * 4) + (y + toolArea.Y) * stride + 3] = color.A;
                        }
                    }
                }
            }

            // Unlock the bitmap memory area
            bmp.UnlockBits(data);
        }
    }
}
