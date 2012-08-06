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
        private float m_magnification = 1.0f;
        private Picture m_picture;
        internal CanvasSession m_session;

        public float magnification { get { return m_magnification; } }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public CanvasWindow(int width = 200, int height = 200, string name = "New Picture")
        {
            InitializeComponent();
            this.Text = name;
            m_picture = new Picture(width, height, name);
            this.SetClientSizeCore((int)(m_picture.Width), (int)(m_picture.Height));
            SetZoom(1.5f);
        }


        public void SetZoom(float pMaginfication) {
            m_magnification = pMaginfication;
            this.AutoScrollMinSize = new Size((int)(m_picture.Width * m_magnification), (int)(m_picture.Height * m_magnification));   // Make the window add scroll bars if nesasery
            canvasBox.Size = new Size((int)(m_picture.Width * m_magnification), (int)(m_picture.Height * m_magnification));   // Make the window add scroll bars if nesasery
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
            Rectangle sampleRectagle = e.ClipRectangle;
            sampleRectagle.X = (int)(sampleRectagle.X / magnification);
            sampleRectagle.Y = (int)(sampleRectagle.Y / magnification);
            sampleRectagle.Width = (int)(sampleRectagle.Width / m_magnification);
            sampleRectagle.Height = (int)(sampleRectagle.Height / m_magnification);
            Rectangle targetRectangle = e.ClipRectangle;
            m_picture.DrawPicture(e.Graphics,targetRectangle, sampleRectagle);
        }

        public void Redraw( ToolRunner pController ) 
        {
            canvasBox.Invalidate();
        }
    }
}
