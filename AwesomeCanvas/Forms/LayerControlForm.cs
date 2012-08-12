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
        Picture m_currentPicture; // The currently selected working picture
        LayerControl[] m_layerControls = null;
        CanvasSession m_canvasSession = null;

        Dictionary<int, int> m_selectedLayerIndexPerCanvasHashcode = new Dictionary<int, int>();
        //-------------------------------------------------------------------------
        // Contructor
        //-------------------------------------------------------------------------
        public LayerControlForm()
        {
            InitializeComponent();
            this.LayerDisplayPanel.AllowDrop = true;
        }
        
        /// <returns>the currently selected layer index, if none zero is always returned</returns>
        public int GetSelectedLayerIndex() {
            if (m_canvasSession != null && m_selectedLayerIndexPerCanvasHashcode.ContainsKey(m_canvasSession.GetHashCode())) {
                int index = m_selectedLayerIndexPerCanvasHashcode[m_canvasSession.GetHashCode()];
                if (m_canvasSession.GetPicture().layers.Count <= index)
                    index = m_canvasSession.GetPicture().layers.Count - 1;
                return index;
            }
            else {
                return 0;
            }
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
            m_canvasSession.Gui_RemoveLayer(GetSelectedLayerIndex());
        }

        private void OnLayerNameChange(int pLayerIndex, string pPreviousName, string pNewName)
        {
            m_canvasSession.Gui_RenameLayer(pLayerIndex, pNewName);
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
            int selectedIndex = layerControl.GetLayerIndex();
            m_selectedLayerIndexPerCanvasHashcode[m_canvasSession.GetHashCode()] = selectedIndex;
            for (int i = 0; i < m_layerControls.Length; i++) {
                if (i == selectedIndex)
                    m_layerControls[i].LayerActivated();
                else
                    m_layerControls[i].LayerDeactivated();
            }
        }

        //-------------------------------------------------------------------------
        // Rebuild the layers control. This is usually done after a picture change
        //-------------------------------------------------------------------------
        public void RebuildLayerControls()
        {
            Console.WriteLine("rebuild");
            // Delete current layer controls
            LayerDisplayPanel.Controls.Clear();
            
            // Cycle through each layer
            int layerIndex = 0;
            List<LayerControl> controls = new List<LayerControl>();
            foreach (Layer layer in m_canvasSession.GetPicture().layers)
            {
                LayerControl lc = new LayerControl(layer.Name, layerIndex++);
                lc.layerNameChanged += new LayerNameChaged(OnLayerNameChange);
                lc.layerControlSelected += new LayerControlSelected(OnLayerSelectionChange);
                lc.layerDragStart += LayerControl_StartDrag;
                this.LayerDisplayPanel.Controls.Add(lc);
                controls.Add(lc);
                
            }
            m_layerControls = controls.ToArray();
            for (int i = 0; i < m_layerControls.Length; i++) {
                UpdateThumbnail(i);
            }
            OnLayerSelectionChange(m_layerControls[GetSelectedLayerIndex()]);
        }

        LayerControl _draggedLayer = null;
        int _draggedLayerStartIndex = 0;
        private void LayerControl_StartDrag(object sender, MouseEventArgs e) {
            _draggedLayer = sender as LayerControl;
            if (_draggedLayer != null) {
                _draggedLayerStartIndex = _draggedLayer.GetLayerIndex();
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
                m_canvasSession.Gui_SwapLayers(_draggedLayerStartIndex, resultingIndex);
                
            }
            _draggedLayer = null;
        }
 

        internal void UpdateThumbnail(int p) {
            if(m_layerControls != null && p < m_layerControls.Length)
            {
                Layer l = m_canvasSession.GetPicture().layers[p];
                m_layerControls[p].Redraw(l);
            }
            
        }


    }
}
