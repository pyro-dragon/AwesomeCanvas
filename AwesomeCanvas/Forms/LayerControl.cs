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
    // A UI component used to represent a layer in a drawing
    public partial class LayerControl : UserControl
    {
        // Constructor
        public LayerControl()
        {
            InitializeComponent();
        }

        // Event triggered when focus on the layer name box is lost
        private void layerNameBox_Leave(object sender, EventArgs e)
        {
            DeactivateLayerNameBox();
        }

        // Even triggered when the control's right pannel is double-clicked
        private void layerControlSplitContainer_Panel2_DoubleClick(object sender, EventArgs e)
        {
            ActiveLayerNameBox();
        }

        // Event triggered when an key-up event is detected in the layer name box
        private void layerNameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DeactivateLayerNameBox();
        }

        // Actions to carry out when the layer name text box is activated - we are renaming a layer
        private void ActiveLayerNameBox()
        {
            // Enable the text input box
            layerNameBox.Enabled = true;

            // Set the colour
            layerNameBox.BackColor = Color.White;

            // Set the boarder style
            layerNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Focus on the text input box
            layerNameBox.Focus();

            // Select all text in the text box
            layerNameBox.SelectAll();
        }

        // Actions to carry out when the layer name text box is deactivated - we are done renaming a layer
        private void DeactivateLayerNameBox()
        {
            // Disable the text input box
            layerNameBox.Enabled = false;

            // Set the volour back to normal
            layerNameBox.BackColor = SystemColors.Control;

            // Get rid of the border
            layerNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // TODO: Trigger layer renameing event
        }

        // Event for when the layer control is clicked - selecting it
        private void LayerControl_Click(object sender, EventArgs e)
        {
            // TODO: Triger event that tells the manager that another layer has been selected

            // Indicate this layer is active
            
        }

        // Actions carried out when the layer is selected
        private void LayerActivated()
        {
            this.BackColor = SystemColors.Highlight;
        }

        // Actions carried out when the layer is deselected
        private void LayerDeactivated()
        {
            this.BackColor = SystemColors.Control;
        }
    }
}
