using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AwesomeCanvas.Application.Controller;
using AwesomeCanvas.Application;
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
        Controller m_localController;

        //-------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------
        public BaseApp(MainForm mainForm)
        {
            // Initalise
            m_pictureList = new ArrayList();
            mainForm.OnGUIToolChanged += new GUIToolChange(this.GUIToolChange);
            mainForm.OnGUINewPicture += new GUINewPictureCreated(this.NewPicFinalisation);
            m_localController = new Controller("localUserInput");
        }
        private void GUIToolChange(ToolStripButton name)
        {
            EzJson j = new EzJson();
            j.BeginFunction("change_tool");
            j.AddData("tool", name.Text);
            m_localController.ParseJSON(j.Finish());
        }

        //---------------------------------------------------------------------
        // Add event handlers to the new picture window
        //---------------------------------------------------------------------
        private void NewPicFinalisation(CanvasWindow window)
        { 
            // Add tool events
            window.canvasBox.MouseDown += new MouseEventHandler(ReciveCanvasMouseDown);
            window.canvasBox.MouseUp += new MouseEventHandler(ReciveCanvasMouseUp);
            window.canvasBox.MouseMove += new MouseEventHandler(ReciveCanvasMouseMove);
            Redraw += new RedrawHandler(window.Redraw);
        }

        //-------------------------------------------------------------------------
        // Add a new picture to the list
        //-------------------------------------------------------------------------
        public void AddPicture(Picture picture)
        {
            m_pictureList.Add(picture);

            // Activate drawing controls
            if (m_pictureList.Count == 1)
            {
                m_localController.SetPicture(m_pictureList[0] as Picture);
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

        public void ReciveCanvasMouseUp(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_up");
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
            (sender as System.Windows.Forms.PictureBox).Invalidate();
        }

        public void ReciveCanvasMouseDown(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_down");
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
            (sender as System.Windows.Forms.PictureBox).Invalidate();
        }

        public void ReciveCanvasMouseMove(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_move");
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
            (sender as System.Windows.Forms.PictureBox).Invalidate();
        }
        public void ReciveSizeChanged( int pNewSize ) {
            EzJson j = new EzJson();
            j.BeginFunction("tool_size");
            j.AddData("size", pNewSize.ToString());
            m_localController.ParseJSON(j.Finish());
        }

        public void IssueRedraw() {
            if (Redraw != null)
                Redraw();
        }
    }
}
