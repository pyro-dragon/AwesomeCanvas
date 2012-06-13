using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    //public delegate void CanvasMouseEvent(CanvasWindow window, MouseEventArgs args);

    //-------------------------------------------------------------------------
    // The form that contains a picture and displays it
    //-------------------------------------------------------------------------
    public partial class CanvasWindow : Form
    {
        // Member variables
        private Picture m_picture;
        private BaseApp m_baseApp;

        //public event CanvasMouseEvent MouseButtonDown;
        //public event CanvasMouseEvent MouseButtonUp;
        //public event CanvasMouseEvent MouseButtonClick;
        //public event CanvasMouseEvent MouseMoved;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public CanvasWindow(BaseApp baseApp, int width = 200, int height = 200, string name = "New Picture")
        {
            InitializeComponent();
            m_baseApp = baseApp;
            this.SetClientSizeCore(width, height);
            this.Text = name;
            this.AutoScrollMinSize = new Size(width, height);   // Make the window add scroll bars if nesasery
            m_picture = new Picture(width, height, name);
        }

        //---------------------------------------------------------------------
        // Return the picture that is being used
        //---------------------------------------------------------------------
        public Picture GetPicture()
        {
            return m_picture;
        }

        //---------------------------------------------------------------------
        // Draw the canvas
        //---------------------------------------------------------------------
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            m_picture.DrawPicture(e.Graphics);
        }

        //---------------------------------------------------------------------
        // A mouse button has been pressed down
        //---------------------------------------------------------------------
        //private void CanvasWindow_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //m_baseApp.GetActiveTool().MouseDown(this, e);
        //    MouseButtonDown(this, e);
        //}

        ////---------------------------------------------------------------------
        //// A mouse button has been released
        ////---------------------------------------------------------------------
        //private void CanvasWindow_MouseUp(object sender, MouseEventArgs e)
        //{
        //    MouseButtonUp(this, e);
        //}

        ////---------------------------------------------------------------------
        //// The mouse hase been moved
        ////---------------------------------------------------------------------
        //private void CanvasWindow_MouseMove(object sender, MouseEventArgs e)
        //{
        //    MouseMoved(this, e);
        //}

        ////---------------------------------------------------------------------
        //// The mouase button has been clicked
        ////---------------------------------------------------------------------
        //private void CanvasWindow_MouseClick(object sender, MouseEventArgs e)
        //{
        //    //m_baseApp.GetActiveTool().MouseEvent(sender, e);
        //    MouseButtonClick(this, e);
        //}
    }
}
