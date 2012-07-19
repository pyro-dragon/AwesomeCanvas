using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AwesomeCanvas;
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
        public CanvasWindow canvasWindow { get { return m_canvasWindow; } }
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
            
            m_localController.OnCanvasNeedsRedraw = m_canvasWindow.Redraw;

        }

        public void GuiInput_MouseUp(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_up");
            j.AddData("x", e.X);
            j.AddData("y", e.Y);
            j.AddData("pressure", 0);
            m_localController.ParseJSON(j.Finish());
        }

        public void GuiInput_MouseDown(object sender, MouseEventArgs e)
        {
            string toolName = m_mainForm.GetToolName();
            EzJson j = new EzJson();
            j.BeginFunction("tool_down");
            j.AddData("pressure", (128).ToString());
            j.AddData("x", e.X);
            j.AddData("y", e.Y);
            j.AddData("layer", 0);
            j.AddData("tool", toolName);
            switch (toolName) {
                case "brush":
                    j.AddData("options", m_mainForm.GetBrushOptions());
                break;
                case "pen":
                    j.AddData("options", m_mainForm.GetPenOptions());
                break;
                default:
                    j.AddData("options", null);
                break;
            }
            m_localController.ParseJSON(j.Finish());
        }

        public void GuiInput_MouseMove(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_move");
            j.AddData("pressure", (128).ToString());
            j.AddData("x", e.X.ToString());
            j.AddData("y", e.Y.ToString());
            m_localController.ParseJSON(j.Finish());
        }

  

    }
}
