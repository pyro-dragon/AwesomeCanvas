using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

[
    ToolStripItemDesignerAvailability
        (ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)
    ]

public class ToolStripColourSwatch : ToolStripControlHost
{
    public Panel trackBar;

    public ToolStripColourSwatch()
        : base(new Panel())
    {
        trackBar = (Panel)this.Control;
        trackBar.AutoSize = false;
    }
}
