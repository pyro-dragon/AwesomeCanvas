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
    // LayerControlForm Provides following model input
    // create_layer
    // remove_layer
    // name_layer
    // swap_layer_position
    // LayerControlForm remembers the selected layer index for each canvas
    //-------------------------------------------------------------------------
    public partial class LayerControlForm : UserControl
    {
        //private event OnLayerNameChange(Layer layer, String name)
        Dictionary<string, LayerControl> m_layerControls = new Dictionary<string,LayerControl>();
        CanvasSession m_canvasSession = null;
        //-------------------------------------------------------------------------
        // Contructor
        //-------------------------------------------------------------------------
        public LayerControlForm()
        {
            InitializeComponent();
            this.LayerDisplayPanel.AllowDrop = true;
        }

        string selectedIndex { 
            get { return m_canvasSession.selectedLayerID; }
            set { m_canvasSession.selectedLayerID = value; }
        }
        

        //-------------------------------------------------------------------------
        // New Layer Button click event
        //-------------------------------------------------------------------------
        private void newLayerButton_Click(object sender, EventArgs e){
            m_canvasSession.Gui_CreateLayer();
        }
        /// <summary>
        /// delete layer button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteLayerButton_Click(object sender, EventArgs e) {
            m_canvasSession.Gui_RemoveLayer(selectedIndex);
        }

        private void OnLayerNameChange(string pLayerID, string pPreviousName, string pNewName)
        {
            m_canvasSession.Gui_RenameLayer(pLayerID, pNewName);
        }

        public void SetCanvasSession(CanvasSession pSession) {
            m_canvasSession = pSession;
            RebuildLayerControls();
        }

        //-------------------------------------------------------------------------
        // Event handler for a layer selection event
        //-------------------------------------------------------------------------
        private void OnLayerSelectionChange(LayerControl layerControl)
        {
            selectedIndex = layerControl.GetLayerID();
            foreach(LayerControl lc in m_layerControls.Values)
            {
                if (lc == layerControl)
                    lc.LayerActivated();
                else
                    lc.LayerDeactivated();
            }
        }

        //-------------------------------------------------------------------------
        // Rebuild the layers control. This is usually done after a picture change
        //-------------------------------------------------------------------------
        public void RebuildLayerControls()
        {
            // Delete current layer controls
            
            SuspendDraw.Suspend(LayerDisplayPanel); //suspend redraw to reduce lag
            //LayerDisplayPanel.SuspendLayout();
            LayerDisplayPanel.Controls.Clear();
            m_layerControls.Clear();
            // Cycle through each layer
            List<LayerControl> controls = new List<LayerControl>();
            foreach (Layer layer in m_canvasSession.GetPicture().layers)
            {
                LayerControl lc = new LayerControl(layer.Name, layer.ID);
                lc.layerNameChanged += new LayerNameChaged(OnLayerNameChange);
                lc.layerControlSelected += new LayerControlSelected(OnLayerSelectionChange);
                lc.layerDragStart += LayerControl_StartDrag;
                m_layerControls.Add(lc.GetLayerID(), lc);
                this.LayerDisplayPanel.Controls.Add(lc);
                controls.Add(lc);
            }
            foreach (Layer layer in m_canvasSession.GetPicture().layers) {
                UpdateThumbnail(layer.ID);
            }
            if (m_layerControls.ContainsKey(selectedIndex)) {
                OnLayerSelectionChange(m_layerControls[selectedIndex]);
            }
            //LayerDisplayPanel.ResumeLayout();
            SuspendDraw.Resume(LayerDisplayPanel);
            
        }

        internal void UpdateThumbnail(string pLayerID) {
            if(m_layerControls != null)
            {
                Layer l = m_canvasSession.GetPicture().GetLayer(pLayerID);
                m_layerControls[pLayerID].Redraw(l);
            }
            
        }

        #region dragDrop
        LayerControl _draggedLayer = null;
        int _draggedLayerStartIndex = 0;
        private void LayerControl_StartDrag(object sender, MouseEventArgs e) {
            _draggedLayer = sender as LayerControl;
            if (_draggedLayer != null) {
                _draggedLayerStartIndex = LayerDisplayPanel.Controls.IndexOf(_draggedLayer);
                this.LayerDisplayPanel.DoDragDrop(_draggedLayer, DragDropEffects.Move);
            }
        }

        private void LayerDisplayPanel_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
            if (_draggedLayer != null) {
                Point mousePosition = LayerDisplayPanel.PointToClient(new Point(e.X, e.Y));
                Control destination = LayerDisplayPanel.GetChildAtPoint(mousePosition);
                int indexSource = LayerDisplayPanel.Controls.IndexOf(_draggedLayer);
                int indexDestination = LayerDisplayPanel.Controls.IndexOf(destination);
                if (indexDestination != -1 && indexSource != indexDestination) {
                    LayerDisplayPanel.Controls.SetChildIndex(_draggedLayer, indexDestination); //swap locations
                    LayerDisplayPanel.Controls.SetChildIndex(destination, indexSource); //swappyswap
                }
            }
        }
        private void LayerDisplayPanel_DragDrop(object sender, DragEventArgs e) {
            int resultingIndex = LayerDisplayPanel.Controls.IndexOf(_draggedLayer);
            if (_draggedLayerStartIndex != resultingIndex) {
                var order = new List<string>();
                foreach (LayerControl lc in LayerDisplayPanel.Controls)
                    order.Add(lc.GetLayerID());
                m_canvasSession.Gui_SetLayerOrder(order.ToArray());
            }
            _draggedLayer = null;
        }
        #endregion


    }
}
