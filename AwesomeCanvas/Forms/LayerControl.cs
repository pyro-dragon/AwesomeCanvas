﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    public delegate void LayerNameChaged(string pLayerID, string pPreviousName, string pNewName);
    public delegate void LayerControlSelected(LayerControl layerControl);

    //-------------------------------------------------------------------------
    // A UI component used to represent a layer in a drawing
    //-------------------------------------------------------------------------
    public partial class LayerControl : UserControl
    {
        // Variables
        string m_layerID;
        Layer m_cachedLayer = null;
        // Events
        public event LayerNameChaged layerNameChanged;
        public event LayerControlSelected layerControlSelected;
        public event MouseEventHandler layerDragStart;
        //-------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------
        public LayerControl(string pLayerName, string pLayerID)
        {
            InitializeComponent();
            m_layerID = pLayerID;
            layerNameBox.Text = pLayerName;
        }
        public void Redraw(Layer pLayer) {
            m_cachedLayer = pLayer;
            previewImageBox.Invalidate();
            previewImageBox.Update();
        }
        //-------------------------------------------------------------------------
        // Event triggered when focus on the layer name box is lost
        //-------------------------------------------------------------------------
        private void layerNameBox_Leave(object sender, EventArgs e)
        {
            DeactivateLayerNameBox();
        }

        //-------------------------------------------------------------------------
        // Even triggered when the control's right pannel is double-clicked
        //-------------------------------------------------------------------------
        private void layerControlSplitContainer_Panel2_DoubleClick(object sender, EventArgs e)
        {
            ActiveLayerNameBox();
        }

        //-------------------------------------------------------------------------
        // Event triggered when an key-up event is detected in the layer name box
        //-------------------------------------------------------------------------
        private void layerNameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                DeactivateLayerNameBox();
        }

        //-------------------------------------------------------------------------
        // Actions to carry out when the layer name text box is activated - we are 
        // renaming a layer
        //-------------------------------------------------------------------------
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

        //-------------------------------------------------------------------------
        // Actions to carry out when the layer name text box is deactivated - 
        // we are done renaming a layer
        //-------------------------------------------------------------------------
        private void DeactivateLayerNameBox()
        {
            // Disable the text input box
            layerNameBox.Enabled = false;

            // Set the volour back to normal
            layerNameBox.BackColor = SystemColors.Control;

            // Get rid of the border
            layerNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;

            // TODO: Trigger layer renameing event
            layerNameChanged(m_layerID, layerNameBox.Text, layerNameBox.Text);
        }

        //-------------------------------------------------------------------------
        // Event for when the layer control is clicked - selecting it
        //-------------------------------------------------------------------------
        private void LayerControl_Click(object sender, EventArgs e)
        {
            // Triger event that tells the manager that another layer has been selected
            layerControlSelected(this);
        }

        //-------------------------------------------------------------------------
        // Actions carried out when the layer is selected
        //-------------------------------------------------------------------------
        public void LayerActivated()
        {
            this.BackColor = SystemColors.Highlight;
        }

        //-------------------------------------------------------------------------
        // Actions carried out when the layer is deselected
        //-------------------------------------------------------------------------
        public void LayerDeactivated()
        {
            this.BackColor = SystemColors.Control;
        }

        //-------------------------------------------------------------------------
        // Return the layer index
        //-------------------------------------------------------------------------
        public string GetLayerID()
        {
            return m_layerID;
        }

        private void previewImageBox_MouseDown(object sender, MouseEventArgs e) {
            if (layerDragStart != null)
                layerDragStart(this, e);
        }
        
        private void previewImageBox_Paint(object sender, PaintEventArgs e) {
            if (m_cachedLayer != null) {

                Rectangle sampleRectagle = m_cachedLayer.GetArea();
                Rectangle targetRectangle = e.ClipRectangle;
                m_cachedLayer.Draw(e.Graphics, targetRectangle, sampleRectagle, true);
             
            }
        }
    }
}
