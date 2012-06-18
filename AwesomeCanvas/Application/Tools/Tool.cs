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
        protected BaseApp m_baseApp;

        //public Tool()   
        //{ 
            
        //}

        public Tool(BaseApp baseApp)
        {
            m_baseApp = baseApp;
        }


        public virtual void MouseEvent(object sender, MouseEventArgs e)
        { }

        public virtual void MouseClick(CanvasWindow sender, MouseEventArgs current, MouseEventArgs previouse)
        { }

        public virtual void MouseDown(CanvasWindow sender, MouseEventArgs current, MouseEventArgs previouse)
        { }

        public virtual void MouseUp(CanvasWindow sender, MouseEventArgs current, MouseEventArgs previouse)
        { }

        public virtual void MouseMove(CanvasWindow sender, MouseEventArgs current, MouseEventArgs previouse)
        { }

        public virtual void MouseEnter(CanvasWindow sender, EventArgs current)
        { }

        public virtual void MouseExit(CanvasWindow sender, EventArgs current)
        { }

    }
}
