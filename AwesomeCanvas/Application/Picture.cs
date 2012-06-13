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
        private List<Layer> m_layers;
        public Layer CurrentLayer { get; set; }
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
            m_layers = new List<Layer>();
            m_layers.Add(new Layer(width, height, "Layer 1"));
            CurrentLayer = m_layers[0];

            // Set layer1's colour to white
            // TODO: Let the user pick the starting colour
            using (Graphics graphics = Graphics.FromImage(m_layers[0].GetBitmap()))
            {
                graphics.Clear(Color.White);
            }
        }

        //---------------------------------------------------------------------
        // A function to render the picture to the panel
        //---------------------------------------------------------------------
        public void DrawPicture(Graphics graphics)
        {
            foreach (Layer layer in m_layers)
            {
                if (layer.Visible)
                {
                    layer.Draw(graphics);
                }
            }
        }

        //---------------------------------------------------------------------
        // A mouse button has been pressed down
        //---------------------------------------------------------------------
        private void MouseDown()
        {

        }

        //---------------------------------------------------------------------
        // A mouse button has been released
        //---------------------------------------------------------------------
        private void MouseUp()
        {

        }

        //---------------------------------------------------------------------
        // The mouse hase been moved
        //---------------------------------------------------------------------
        private void MouseMove()
        {

        }

        //---------------------------------------------------------------------
        // The mouase button has been clicked
        //---------------------------------------------------------------------
        private void MouseClick()
        {
            
        }
    }
}
