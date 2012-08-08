using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    //-------------------------------------------------------------------------
    // A for that is used to control the order of layers. It can create and 
    // delete them too.
    //-------------------------------------------------------------------------
    public partial class LayerControlForm : UserControl
    {
        //private event OnLayerNameChange(Layer layer, String name)
        private Picture currentPicture; // The currently selected working picture

        //-------------------------------------------------------------------------
        // Contructor
        //-------------------------------------------------------------------------
        public LayerControlForm()
        {
            InitializeComponent();

        }

        //-------------------------------------------------------------------------
        // New Layer Button click event
        //-------------------------------------------------------------------------
        private void newLayerButton_Click(object sender, EventArgs e)
        {
            currentPicture.AddLayer();

            RebuildLayerControls();
        }

        private void OnLayerNameChange(Layer layer, String name)
        { 
            
        }


        //-------------------------------------------------------------------------
        // Event handler for a layer selection event
        //-------------------------------------------------------------------------
        private void OnLayerSelectionChange(LayerControl layerControl)
        {
            foreach (Control c in LayerDisplayPanel.Controls)
            {
                LayerControl lc = (LayerControl)c;
                if (lc != layerControl)
                    lc.LayerDeactivated();
                else
                    lc.LayerActivated();
                    
            }
        }

        //-------------------------------------------------------------------------
        // Action to carry out when the picture focus has been changed
        //-------------------------------------------------------------------------
        public void ChangePictureFocus(Picture picture)
        {
            // Set the currently selected picture
            currentPicture = picture;

            // Rebuild the layer controls
            RebuildLayerControls();
        }

        //-------------------------------------------------------------------------
        // Rebuild the layers control. This is usually done after a picture change
        //-------------------------------------------------------------------------
        public void RebuildLayerControls()
        {
            // Delete current layer controls
            LayerDisplayPanel.Controls.Clear();
            
            // Cycle through each layer
            foreach (Layer layer in currentPicture.layers)
            {
                LayerControl lc = new LayerControl(layer);
                lc.layerNameChanged += new LayerNameChaged(OnLayerNameChange);
                lc.layerControlSelected += new LayerControlSelected(OnLayerSelectionChange);
                this.LayerDisplayPanel.Controls.Add(lc);
            }
        }
    }
}
