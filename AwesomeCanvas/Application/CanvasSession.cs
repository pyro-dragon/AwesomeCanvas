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
    /// <summary>
    ///  this class collects input from the gui
    ///  it also handles the controllers associated with the canvas
    /// </summary>
    public class CanvasSession
    {
        Controller m_localController;
        CanvasWindow m_canvasWindow;
        MainForm m_mainForm;

        public Controller localController { get { return m_localController; } }
        //-------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------
        public CanvasSession(MainForm pMainForm, CanvasWindow pCanvasWindow)
        {
            m_localController = new Controller("localUserInput", pCanvasWindow.GetPicture());
            m_mainForm = pMainForm;
            m_canvasWindow = pCanvasWindow;
            m_canvasWindow.canvasBox.MouseDown += new MouseEventHandler(GuiInput_MouseDown);
            m_canvasWindow.canvasBox.MouseUp += new MouseEventHandler(GuiInput_MouseUp);
            m_canvasWindow.canvasBox.MouseMove += new MouseEventHandler(GuiInput_MouseMove);
            m_canvasWindow.m_session = this;
            
            m_localController.OnCanvasUpdated = m_canvasWindow.Redraw;

        }

        public void GuiInput_MouseUp(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_up");
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
        }

        public void GuiInput_MouseDown(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_down");
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
        }

        public void GuiInput_MouseMove(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_move");
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
        }
        public void GuiInput_ToolSizeChanged( int pNewSize ) {
            EzJson j = new EzJson();
            j.BeginFunction("tool_size");
            j.AddData("size", pNewSize.ToString());
            m_localController.ParseJSON(j.Finish());
        }
        public void GuiInput_ToolSizeChanged(string pToolName) {
            EzJson j = new EzJson();
            j.BeginFunction("change_tool");
            j.AddData("tool", pToolName);
            m_localController.ParseJSON(j.Finish());
        }
        private void GuiInput_ToolChange(ToolStripButton name) {
            EzJson j = new EzJson();
            j.BeginFunction("change_tool");
            j.AddData("tool", name.Text);
            m_localController.ParseJSON(j.Finish());
        }
    }
}
