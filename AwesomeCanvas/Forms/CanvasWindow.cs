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
        internal CanvasSession m_session; 

        //public event CanvasMouseEvent MouseButtonDown;
        //public event CanvasMouseEvent MouseButtonUp;
        //public event CanvasMouseEvent MouseButtonClick;
        //public event CanvasMouseEvent MouseMoved;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public CanvasWindow(int width = 200, int height = 200, string name = "New Picture")
        {
            InitializeComponent();
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

        public void Redraw( Controller pController ) 
        {
            canvasBox.Invalidate();
        }
    }
}
