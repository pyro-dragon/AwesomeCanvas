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
        ToolRunner m_toolRunner;
        CanvasWindow m_canvasWindow;
        MainForm m_mainForm;
        
        public CanvasWindow canvasWindow { get { return m_canvasWindow; } }
        public ToolRunner localController { get { return m_toolRunner; } }
        //-------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------
        public CanvasSession(MainForm pMainForm, CanvasWindow pCanvasWindow)
        {

            m_toolRunner = new ToolRunner("localUserInput", pCanvasWindow.GetPicture());
            m_mainForm = pMainForm;
            m_canvasWindow = pCanvasWindow;
            m_canvasWindow.canvasBox.MouseDown += new MouseEventHandler(GuiInput_MouseDown);
            m_canvasWindow.canvasBox.MouseUp += new MouseEventHandler(GuiInput_MouseUp);
            m_canvasWindow.canvasBox.MouseMove += new MouseEventHandler(GuiInput_MouseMove);
            m_canvasWindow.m_session = this;
            
            m_toolRunner.OnCanvasNeedsRedraw = m_canvasWindow.Redraw;
        }

        public void OnFocus()
        {

        }

        protected void GuiInput_MouseUp(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_up");
            j.AddData("x", (int)(e.X / m_canvasWindow.magnification));
            j.AddData("y", (int)(e.Y / m_canvasWindow.magnification));
            j.AddData("pressure", 0);
            m_toolRunner.ParseJSON(j.Finish());
        }

        protected void GuiInput_MouseDown(object sender, MouseEventArgs e)
        {
            string toolName = m_mainForm.GetToolName();
            EzJson j = new EzJson();
            j.BeginFunction("tool_down");
            j.AddData("pressure", (128).ToString());
            j.AddData("x", (int)(e.X / m_canvasWindow.magnification));
            j.AddData("y", (int)(e.Y / m_canvasWindow.magnification));
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
            m_toolRunner.ParseJSON(j.Finish());
        }

        protected void GuiInput_MouseMove(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_move");
            j.AddData("pressure", (128).ToString());
            j.AddData("x", (int)(e.X / m_canvasWindow.magnification));
            j.AddData("y", (int)(e.Y / m_canvasWindow.magnification));
            m_toolRunner.ParseJSON(j.Finish());
        }

        internal void GuiInput_KeyDown(object sender, KeyEventArgs e) 
        {
  
        }

        internal bool GuiInput_KeyDown(Keys keyData) {
            if (keyData == (Keys.Z | Keys.Control)) {
                    EzJson j = new EzJson();
                    j.BeginFunction("undo");
                    j.AddData("layer", m_mainForm.GetCurrentLayer());
                    m_toolRunner.ParseJSON(j.Finish());
                    
                    Console.WriteLine("undo!");
                    return true;
            }
            else if (keyData == (Keys.X | Keys.Control)) {
                    EzJson j = new EzJson();
                    j.BeginFunction("clear");
                    m_toolRunner.ParseJSON(j.Finish());
                    Console.WriteLine("clear!");
                    return true;
            }
            return false;
        }
    }
}
