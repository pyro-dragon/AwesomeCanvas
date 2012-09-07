using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WintabDN;

namespace AwesomeCanvas
{
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

         // Experimental tablet shit
        CWintabData data;
        float tabletPressure;
        

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
            this.canvasBox.MouseDown += new MouseEventHandler(ProcessMouseDown);  
            this.canvasBox.MouseUp += new MouseEventHandler(ProcessMouseUp); 
            this.canvasBox.MouseMove += new MouseEventHandler(ProcessMouseMove);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;

            tabletPressure = 1.0f;
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
        internal void ProcessMouseUp(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                m_session.GuiInput_PointerUp(sender, e.X, e.Y);
            }
        }

        internal void ProcessMouseDown(object sender, MouseEventArgs e) 
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left) 
            {
                if (m_zoomTool.Enabled) {
                    m_zoomTool.Begin(new Point(e.X, e.Y));
                }
                else if (m_panTool.Enabled) {
                    m_panTool.Begin(new Point(e.X, e.Y));
                }
                else {
                    m_session.GuiInput_PointerDown(sender, e.X, e.Y, tabletPressure);
                }
            }
        }

        internal void ProcessMouseMove(object sender, MouseEventArgs e) {
            //if left button is down

            if (m_zoomTool.Enabled && !Control.ModifierKeys.HasFlag(Keys.Shift))
                m_zoomTool.Enabled = false;

            if (m_panTool.Enabled && !Control.ModifierKeys.HasFlag(Keys.Alt))
                m_panTool.Enabled = false;
       
            if ((Control.MouseButtons & System.Windows.Forms.MouseButtons.Left) != System.Windows.Forms.MouseButtons.None) 
            {
                if (m_zoomTool.Enabled) {
                    m_zoomTool.Move(new Point(e.X, e.Y));
                    
                }
                else if (m_panTool.Enabled) {
                    m_panTool.Move(new Point(e.X, e.Y));
                }
                else {
                    m_session.GuiInput_PointerMove(sender, e.X, e.Y, tabletPressure);
                }
            }
            
        }

        internal bool ProcessKeyDown(Keys pKeys)
        {
            if(pKeys == (Keys.Control | Keys.X))
                m_session.Gui_ClearSelectedLayer();
            else if(pKeys == (Keys.Control | Keys.Z))
                m_session.Gui_Undo();
            else if (pKeys.HasFlag(Keys.Shift))
                m_zoomTool.Enabled = true;
            else if (pKeys.HasFlag(Keys.Alt))
                m_panTool.Enabled = true;
            else if (pKeys.HasFlag(Keys.Oemplus))
                SetZoom(m_magnification * 1.5f, true);
            else if (pKeys.HasFlag(Keys.OemMinus))
                SetZoom(m_magnification / 1.5f, true);
             else 
                return false;
            return true;
           
        }
        internal void SetPanPosition(Point pPoint) {
            this.SetDisplayRectLocation(pPoint.X, pPoint.Y);
            Redraw(null);
        }
        internal Point GetPanPosition() {
            return new Point(this.DisplayRectangle.X, this.DisplayRectangle.Y);
        }

        //---------------------------------------------------------------------
        // Prepare to take tablet input
        //---------------------------------------------------------------------
        private void PrepareForTabletInput(object sender, EventArgs e)
        {
            // Set up the tablet context
            CWintabContext context = new CWintabContext();
            context = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);

            // Allow the mouse to move
            context.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;

            context.Name = "Tablet event data context";
            context.OutOrgX = 0;
            context.OutOrgY = 0;
            context.OutExtX = 800;
            context.OutExtY = 600;

            bool status = context.Open();

            // Prepare to take data
            data = new CWintabData(context);
            data.SetWTPacketEventHandler(TabletEventHandler);
        }

        //---------------------------------------------------------------------
        // Tablet event handler
        //---------------------------------------------------------------------
        private void TabletEventHandler(object sender, MessageReceivedEventArgs args)
        {
            uint pktID = (uint)args.Message.WParam;
            WintabPacket pkt = data.GetDataPacket(pktID);

            if (pkt.pkNormalPressure.pkAbsoluteNormalPressure > 0)
                tabletPressure = (float)pkt.pkNormalPressure.pkAbsoluteNormalPressure / 1024.0f;
        }
    }
}
