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
        float m_magnification = 1.0f;
        Picture m_picture;
        string m_pictureName;
        PanTool m_panTool;
        ZoomTool m_zoomTool;
        
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
            
            m_panTool = new PanTool(this);
            m_zoomTool = new ZoomTool(this);

            SetZoom(1.0f, false);
            this.canvasBox.MouseDown += new MouseEventHandler(OnMouseDown);
            this.canvasBox.MouseUp += new MouseEventHandler(OnMouseUp);
            this.canvasBox.MouseMove += new MouseEventHandler(OnMouseMove);
            this.KeyDown += new KeyEventHandler(OnKeyDown);

        }

        //---------------------------------------------------------------------
        // Set the zoom level of the image
        //---------------------------------------------------------------------
        public void SetZoom(float pMaginfication, bool pForceRedraw) {
            m_magnification = pMaginfication;
            canvasBox.Size = this.AutoScrollMinSize = new Size((int)(m_picture.Width * m_magnification), (int)(m_picture.Height * m_magnification));   // Make the window add scroll bars if nesasery
            if (pForceRedraw)
                Redraw(null);
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
            canvasBox.Invalidate(true);
            canvasBox.Update();
        }
        internal void OnMouseUp(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                m_session.GuiInput_MouseUp(sender, e);
            }
        }

        internal void OnMouseDown(object sender, MouseEventArgs e) 
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) 
            {
                if (m_zoomTool.Enabled) {
                    m_zoomTool.Begin(new Point(e.X, e.Y));
                }
                else if (m_panTool.Enabled) {
                    m_panTool.Begin(new Point(e.X, e.Y));
                }
          /*      else if ((Control.ModifierKeys & Keys.Control) != Keys.None) {
                    SetZoom(m_magnification / 1.5f, true);
                }
                else if ((Control.ModifierKeys & Keys.Shift) != Keys.None) {
                    SetZoom(m_magnification * 1.5f, true);
                }*/
                else {
                    m_session.GuiInput_MouseDown(sender, e);
                }
            }
        }

        internal void OnMouseMove(object sender, MouseEventArgs e) {
            //if left button is down
            if ((Control.MouseButtons & System.Windows.Forms.MouseButtons.Left) != System.Windows.Forms.MouseButtons.None) 
            {
                if (m_zoomTool.Enabled) {
                    m_zoomTool.Move(new Point(e.X, e.Y));
                }
                else if (m_panTool.Enabled) {
                    m_panTool.Move(new Point(e.X, e.Y));
                }
                else {
                    m_session.GuiInput_MouseMove(sender, e);
                }
            }
            
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Shift) != Keys.None || m_zoomTool.Enabled) {
                m_zoomTool.Enabled = false;
            }
            else if ((e.KeyCode & Keys.Space) != Keys.None || m_panTool.Enabled) {
                m_panTool.Enabled = false;
            }
            else if (e.KeyCode == Keys.Oemplus){
                SetZoom(m_magnification * 1.5f, true);
            }
            else if (e.KeyCode == Keys.OemMinus) {
                SetZoom(m_magnification / 1.5f, true);
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e) 
        {
            if ((e.Modifiers & Keys.Shift) != Keys.None) {
                m_zoomTool.Enabled = true;
            }else if ((e.KeyCode & Keys.Space) != Keys.None) {
                m_panTool.Enabled = true;
            }
           
        }
        internal void SetPanPosition(Point pPoint) {
            this.SetDisplayRectLocation(pPoint.X, pPoint.Y);
            Redraw(null);
            //this.Rect
            //this.VerticalScroll.Value = Math.Max(0, pPoint.Y);
            //this.HorizontalScroll.Value =  Math.Max(0, pPoint.X);
        }
        internal Point GetPanPosition() {
            return new Point(this.DisplayRectangle.X, this.DisplayRectangle.Y);
        }

    }
}
