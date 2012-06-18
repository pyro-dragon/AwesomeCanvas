using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    public delegate void RedrawHandler();

    //-------------------------------------------------------------------------
    // The core application from which everything takes its orders
    //-------------------------------------------------------------------------
    public class BaseApp
    {
        public event RedrawHandler Redraw;
        // Member variables
        ArrayList m_pictureList;     // List of currently open pictures
        Tool m_activeTool;   // The current active tool
        MouseStatus MouseStatus { get; set; }
        MouseEventArgs PreviouseMouseState { get; set; }
        PointerTool m_pointerTool;
        PenTool m_penTool;
        BrushTool m_brushTool;

        //-------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------
        public BaseApp(MainForm mainForm)
        {
            // Initalise
            m_pictureList = new ArrayList();
            m_activeTool = new Tool(this);
            mainForm.ChangeTool += new ToolChangeEv(this.ChangeTool);
            mainForm.NewPicCreated += new NewPictureCreatedEv(this.NewPicFinalisation);
            m_pointerTool = new PointerTool(this);
            m_penTool = new PenTool(this);
            m_brushTool = new BrushTool(this);

        }

        //---------------------------------------------------------------------
        // Issue a change tool command 
        //---------------------------------------------------------------------
        private void ChangeTool(ToolStripButton toolName)
        {
            if (toolName.Text.Equals("Brush"))
                m_activeTool = m_brushTool;
            else if (toolName.Text.Equals("Pen"))
                m_activeTool = m_penTool;
            else if (toolName.Text.Equals("Pointer"))
                m_activeTool = m_pointerTool;
            
            Console.WriteLine("Changed tool to" + toolName);
        }

        //---------------------------------------------------------------------
        // Add event handlers to the new picture window
        //---------------------------------------------------------------------
        private void NewPicFinalisation(CanvasWindow window)
        { 
            // Add tool events
            window.canvasBox.MouseClick += new MouseEventHandler(ReciveCanvasMouseClick);
            window.canvasBox.MouseDown += new MouseEventHandler(ReciveCanvasMouseDown);
            window.canvasBox.MouseUp += new MouseEventHandler(ReciveCanvasMouseUp);
            window.canvasBox.MouseMove += new MouseEventHandler(ReciveCanvasMouseMove);
            window.canvasBox.MouseEnter += new EventHandler(ReciveCanvasMouseEnter);
            window.canvasBox.MouseLeave += new EventHandler(ReciveCanvasMouseExit);
            Redraw += new RedrawHandler(window.Redraw);
        }

        //-------------------------------------------------------------------------
        // Create a new a picture
        //-------------------------------------------------------------------------
        //public void CreateNewPicture()
        //{
        //    // Create a new picture
        //    // Fire an event to inform that a new picture has been created. 
        //    NewPictureEv();
        //}

        //-------------------------------------------------------------------------
        // Add a new picture to the list
        //-------------------------------------------------------------------------
        public void AddPicture(Picture picture)
        {
            m_pictureList.Add(picture);

            // Activate drawing controls
            if (m_pictureList.Count == 1)
            { 
                
            }
                
        }

        //-------------------------------------------------------------------------
        // A mouse event has been recived from a canvas window
        //-------------------------------------------------------------------------
        CanvasWindow GetCanvasWindow(object pObject)
        {
            if (pObject is System.Windows.Forms.PictureBox && (pObject as System.Windows.Forms.PictureBox).Parent is CanvasWindow)
            {
                return (pObject as System.Windows.Forms.PictureBox).Parent as CanvasWindow;
            }
            throw new Exception("could not find canvas window");
        }
        public void ReciveCanvasMouseClick(object sender, MouseEventArgs e)
        {
            m_activeTool.MouseClick(GetCanvasWindow(sender), e, PreviouseMouseState);
            PreviouseMouseState = e;
        }

        public void ReciveCanvasMouseUp(object sender, MouseEventArgs e)
        {
            m_activeTool.MouseUp(GetCanvasWindow(sender), e, PreviouseMouseState);
            PreviouseMouseState = e;
        }

        public void ReciveCanvasMouseDown(object sender, MouseEventArgs e)
        {
            m_activeTool.MouseDown(GetCanvasWindow(sender), e, PreviouseMouseState);
            PreviouseMouseState = e;
        }

        public void ReciveCanvasMouseMove(object sender, MouseEventArgs e)
        {
            m_activeTool.MouseMove(GetCanvasWindow(sender), e, PreviouseMouseState);
            PreviouseMouseState = e;
        }

        public void ReciveCanvasMouseEnter(object sender, EventArgs e)
        {
            m_activeTool.MouseEnter(GetCanvasWindow(sender), e);
        }

        public void ReciveCanvasMouseExit(object sender, EventArgs e)
        {
            m_activeTool.MouseExit(GetCanvasWindow(sender), e);
        }


        public Tool GetActiveTool()
        {
            return m_activeTool;
        }

        public void UpdateMouseState()
        {
            //PreviouseMouseState;
        }

        public void IssueRedraw() {
            if (Redraw != null)
                Redraw();
        }
    }
}
