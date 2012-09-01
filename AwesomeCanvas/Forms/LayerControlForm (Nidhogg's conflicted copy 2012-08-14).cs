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
    public delegate void LayerIndexChangedEventHandler(int newLayerIndex);
    //-------------------------------------------------------------------------
    // A for that is used to control the order of layers. It can create and 
    // delete them too.
    //-------------------------------------------------------------------------
    public partial class LayerControlForm : UserControl
    {
        public event LayerIndexChangedEventHandler layerControlSelectedEvent;

        //private event OnLayerNameChange(Layer layer, String name)
        private Picture currentPicture; // The currently selected working picture
        private LayerControl selectedLayerControl;

        //-------------------------------------------------------------------------
        // Contructor
        //-------------------------------------------------------------------------
        public LayerControlForm()
        {
            InitializeComponent();
            selectedLayerControl = null;
        }

        //-------------------------------------------------------------------------
        // New Layer Button click event
        //-------------------------------------------------------------------------
        private void newLayerButton_Click(object sender, EventArgs e)
        {
            // Add a new layer to the picture
            currentPicture.AddLayer();

            // Rebuild the layer display
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
            SetActiveLayerControl(layerControl);
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
            int layerIndex = 0;
            foreach (Layer layer in currentPicture.layers)
            {
                LayerControl lc = new LayerControl(layer, layerIndex++);
                lc.layerNameChanged += new LayerNameChaged(OnLayerNameChange);
                lc.layerControlSelected += new LayerControlSelected(OnLayerSelectionChange);
                if(layerIndex == active)
                this.LayerDisplayPanel.Controls.Add(lc);
            }
        }

        //-------------------------------------------------------------------------
        // Return the currently active layer index
        //-------------------------------------------------------------------------
        public int GetActiveLayerIndex()
        {
            return selectedLayerControl.GetLayerIndex();
        }

        //-------------------------------------------------------------------------
        // Set the selected layer
        //-------------------------------------------------------------------------
        public void SetActiveLayerControl(LayerControl layerControl)
        {
            // Deactivate the currently selected layer
            if (selectedLayerControl != null)
                selectedLayerControl.LayerDeactivated();

            // Activate the newly selected layer
            layerControl.LayerActivated();

            // Set the currently selected layer to the new layer
            selectedLayerControl = layerControl;
        }

        //-------------------------------------------------------------------------
        // Set the selected layer index
        //-------------------------------------------------------------------------
        public void SetActiveLayerControl(int layerIndex)
        {
            // Deactivate the currently selected layer
            if (selectedLayerControl != null)
                selectedLayerControl.LayerDeactivated();

            // Set the currently selected layer to the new layer
            selectedLayerControl = (LayerControl)LayerDisplayPanel.Controls[layerIndex];

            // Activate the newly selected layer
            selectedLayerControl.LayerActivated();
        }
    }
}
