using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AwesomeCanvas
{
    // Event handler delegate
    //public delegate void NewPictureCreatedHandler(Picture picture);
    public delegate void AddNewLayerHandler(Layer layer);
    public delegate void DeleteLayerHandler(Layer layer);
    public delegate void MoveLayerHandler(Layer layer, short position);

    //---------------------------------------------------------------------
    // The class that holds the structure of an image
    //---------------------------------------------------------------------
    public class Picture
    {
        // An event for when the picture is created
        //public event NewPictureCreatedHandler NewPictureEvent;
        public event AddNewLayerHandler AddNewLayerEvent;
        public event DeleteLayerHandler DeleteLayerEvent;
        public event MoveLayerHandler MoveLayerEvent;

        // Member variables
        public List<Layer> layers;
        private int m_width;
        private int m_height;
        private string m_name;
        public int Width { get { return m_width; } }
        public int Height { get { return m_height; } }

        //---------------------------------------------------------------------
        // Contructor
        //---------------------------------------------------------------------
        public Picture(int width, int height, string name)
        {
            m_width = width;
            m_height = height;
            m_name = name;
            layers = new List<Layer>();
            layers.Add(new Layer(width, height, "Layer 0"));

            // Set layer1's colour to white
            // TODO: Let the user pick the starting colour
            Clear();
        }

        //---------------------------------------------------------------------
        // A function to render the picture to the panel
        //---------------------------------------------------------------------
        public void DrawPicture(Graphics graphics, Rectangle pOutputRect, Rectangle pSampleRect)
        {
            // Initialise the layers
            foreach (Layer layer in layers)
            {
                if (layer.Visible) {
                    layer.Draw(graphics, pOutputRect, pSampleRect);
                }
            }
        }

        //-------------------------------------------------------------------------
        // A function used to add a new layer to the picture TODO: Actully fill this thing in
        //-------------------------------------------------------------------------
        public void AddLayer()
        { 
            // Add a new layer
            layers.Add(new Layer(m_width, m_height, "Layer " + layers.Count.ToString()));

            // Inform everyone that there is a new layer
            //AddNewLayerEvent(new Layer);
        }

        public void Clear() {
            // Set layer1's colour to white
            // TODO: Let the user pick the starting colour
            for (int i = 0; i < layers.Count; i++ ){
                using (Graphics graphics = Graphics.FromImage(layers[i].GetBitmap())) {
                    graphics.Clear(Color.White);
                }
            }
        }
    }
}
