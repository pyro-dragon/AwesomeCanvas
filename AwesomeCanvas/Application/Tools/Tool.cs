using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    // The base object for tools
    public class Tool
    {
        public Tool()   
        { 
            
        }

        public virtual void MouseEvent(object sender, MouseEventArgs e)
        { }

        public virtual void MouseClick(CanvasWindow sender, MouseEventArgs e)
        { }

        public virtual void MouseDown(CanvasWindow sender, MouseEventArgs e)
        { }

        public virtual void MouseUp(CanvasWindow sender, MouseEventArgs e)
        { }

        public virtual void MouseMove(CanvasWindow sender, MouseEventArgs e)
        { }

        public virtual void MouseEnter(CanvasWindow sender, EventArgs e)
        { }

        public virtual void MouseExit(CanvasWindow sender, EventArgs e)
        { }

    }
}
