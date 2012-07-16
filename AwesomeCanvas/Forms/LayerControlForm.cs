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
        public LayerControlForm()
        {
            InitializeComponent();

        }

        private void newLayerButton_Click(object sender, EventArgs e)
        {
            LayerControl lc = new LayerControl();
            //lc.Dock = DockStyle.Top;
            //lc.Show();
            this.LayerDisplayPanel.Controls.Add(lc);
        }
    }
}
