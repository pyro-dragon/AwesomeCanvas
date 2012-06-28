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
    public partial class LayerControl : UserControl
    {
        public LayerControl()
        {
            InitializeComponent();
        }

        private void layerNameBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Enabled = true;
        }

        private void layerNameBox_Leave(object sender, EventArgs e)
        {
            this.Enabled = false;
        }

        private void layerNameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Equals(Keys.Enter))
                this.Enabled = false;
        }
    }
}
