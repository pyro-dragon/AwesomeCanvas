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

public class ToolStripTrackBarItem : ToolStripControlHost
{
    public CustomTrackbar trackBar;

    public ToolStripTrackBarItem()
        : base(new CustomTrackbar())
    {
        trackBar = (CustomTrackbar)this.Control;
        trackBar.AutoSize = false;
        trackBar.Maximum = 100;
        trackBar.Size = new Size(200, 20);
        trackBar.TickFrequency = 1;
        trackBar.TickStyle = TickStyle.None;
    }
}
public class CustomTrackbar : TrackBar
{
    protected override void OnGotFocus(EventArgs e) {
        //base.OnGotFocus(e);
    }

}