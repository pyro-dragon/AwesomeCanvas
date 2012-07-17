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
    public partial class LayerControlForm : UserControl
    {
        //private event OnLayerNameChange(Layer layer, String name)

        public LayerControlForm()
        {
            InitializeComponent();

        }

        private void newLayerButton_Click(object sender, EventArgs e)
        {
            LayerControl lc = new LayerControl(new Layer(1,1,"a"));
            lc.layerNameChanged += new LayerNameChaged(OnLayerNameChange);
            lc.layerControlSelected += new LayerControlSelected(OnLayerSelectionChange);
            this.LayerDisplayPanel.Controls.Add(lc);
        }

        private void OnLayerNameChange(Layer layer, String name)
        { 
            
        }

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
    }
}
