using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
namespace AwesomeCanvas
{


    //---------------------------------------------------------------------
    // The class that holds the structure of an image
    //---------------------------------------------------------------------
    public class Picture
    {
        // An event for when the picture is created
        //public event NewPictureCreatedHandler NewPictureEvent;

        // Member variables
        private List<Layer> m_layers;
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
            m_layers = new List<Layer>();
            // Set layer1's colour to white
            // TODO: Let the user pick the starting colour
        }

        //---------------------------------------------------------------------
        // A function to render the picture to the panel
        //---------------------------------------------------------------------
        public void DrawPicture(Graphics graphics, Rectangle pOutputRect, Rectangle pSampleRect)
        {
            // Initialise the m_layers
            foreach (Layer layer in m_layers)
            {
                if (layer.Visible) {
                    layer.Draw(graphics, pOutputRect, pSampleRect);
                }
            }
        }

        //-------------------------------------------------------------------------
        // A function used to add a new layer to the picture TODO: Actully fill 
        // this thing in
        //-------------------------------------------------------------------------
        public void AddLayer( string pId )
        { 
            // Add a new layer
            m_layers.Add(new Layer(m_width, m_height, "Layer " + m_layers.Count.ToString(), pId));

            // Inform everyone that there is a new layer
            //AddNewLayerEvent(new Layer);
        }

        public void Clear(string pLayerID) {
            // TODO: Let the user pick the starting colour
            Layer l = GetLayer(pLayerID);
            using (Graphics graphics = Graphics.FromImage(l.GetBitmap())) {
                graphics.Clear(Color.White);
            }
        }
        public void ClearAll() {
            foreach (Layer l in m_layers) {
                Clear(l.ID);
            }
        }

        internal void RemoveLayer(string pLayerID) {
            m_layers.Remove(GetLayer(pLayerID));
        }

        public IEnumerable<Layer> layers { get { return m_layers; } }
        public Layer GetLayer(string pID) {
            return m_layers.First((p) => p.ID == pID);
        }

        public int GetLayerCount() {
            return m_layers.Count;
        }

        internal void Reorder_layers(string[] pNewLayerOrder) {
            Debug.Assert(pNewLayerOrder.Length == m_layers.Count, "layer order does not match setup");
            Layer[] oldOrder = m_layers.ToArray();
            m_layers.Clear();
            foreach (string s in pNewLayerOrder) {
               Layer t = oldOrder.First((l) => { return l.ID == s; });
               Debug.Assert(t != null, "layer order does not match setup");
               m_layers.Add(t);
            }
        }
    }
}
