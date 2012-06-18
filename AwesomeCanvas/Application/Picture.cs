using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AwesomeCanvas
{
    //---------------------------------------------------------------------
    // The class that holds the structure of an image
    //---------------------------------------------------------------------
    public class Picture
    {
        // Member variables
        public List<Layer> layers;
        private int m_width;
        private int m_height;
        private string m_name;

        //---------------------------------------------------------------------
        // Contructor
        //---------------------------------------------------------------------
        public Picture(int width, int height, string name)
        {
            m_width = width;
            m_height = height;
            m_name = name;
            layers = new List<Layer>();
            layers.Add(new Layer(width, height, "Layer 1"));

            // Set layer1's colour to white
            // TODO: Let the user pick the starting colour
            using (Graphics graphics = Graphics.FromImage(layers[0].GetBitmap()))
            {
                graphics.Clear(Color.White);
            }
        }

        //---------------------------------------------------------------------
        // A function to render the picture to the panel
        //---------------------------------------------------------------------
        public void DrawPicture(Graphics graphics)
        {
            foreach (Layer layer in layers)
            {
                if (layer.Visible)
                {
                    layer.Draw(graphics);
                }
            }
        }
    }
}
