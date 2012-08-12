using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AwesomeCanvas;
using System.IO;
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
        LayerControlForm m_layerControl;
        
        public CanvasWindow canvasWindow { get { return m_canvasWindow; } }
        public ToolRunner localController { get { return m_toolRunner; } }
        //-------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------
        public CanvasSession(MainForm pMainForm, CanvasWindow pCanvasWindow, LayerControlForm pLayerControlForm)
        {
            m_toolRunner = new ToolRunner("localUserInput", pCanvasWindow.GetPicture());
            m_mainForm = pMainForm;
            m_canvasWindow = pCanvasWindow;
            m_canvasWindow.m_session = this;
            m_layerControl = pLayerControlForm;
            
            //add listeners for all functions that should redraw the main canvas
            m_toolRunner.AddFunctionListener( (pA, pB, pC) => { m_canvasWindow.Redraw(pA); }, "tool_down", "tool_up", "tool_move", "undo", "clear", "swap_layers", "remove_layer");

            //add listeners for all functions that should rebuild the layer list
            m_toolRunner.AddFunctionListener((pA, pB, pC) => { m_layerControl.RebuildLayerControls(); }, "swap_layers", "rename_layer", "remove_layer", "create_layer");
            
            //add listeners for all functions that should update a layer thumbnail
            m_toolRunner.AddFunctionListener((pA, pB, pC) => { m_layerControl.UpdateThumbnail(Convert.ToInt32(pC["layer"])); }, "tool_up", "undo");
        }

        internal void GuiInput_MouseUp(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_up");
            j.AddData("x", (int)(e.X / m_canvasWindow.magnification));
            j.AddData("y", (int)(e.Y / m_canvasWindow.magnification));
            j.AddData("pressure", 0);
            j.AddData("layer", m_layerControl.GetSelectedLayerIndex());
            m_toolRunner.ParseJSON(j.Finish());
        }

        internal void GuiInput_MouseDown(object sender, MouseEventArgs e)
        {
            string toolName = m_mainForm.GetToolName();
            EzJson j = new EzJson();
            j.BeginFunction("tool_down");
            j.AddData("pressure", (128).ToString());
            j.AddData("x", (int)(e.X / m_canvasWindow.magnification));
            j.AddData("y", (int)(e.Y / m_canvasWindow.magnification));
            j.AddData("layer", m_layerControl.GetSelectedLayerIndex());
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

        internal void GuiInput_MouseMove(object sender, MouseEventArgs e)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_move");
            j.AddData("pressure", (128).ToString());
            j.AddData("x", (int)(e.X / m_canvasWindow.magnification));
            j.AddData("y", (int)(e.Y / m_canvasWindow.magnification));
            m_toolRunner.ParseJSON(j.Finish());
        }


        internal bool GuiInput_KeyDown(Keys keyData) {
            if (keyData == (Keys.Z | Keys.Control)) {
                    EzJson j = new EzJson();
                    j.BeginFunction("undo");
                    j.AddData("layer", m_layerControl.GetSelectedLayerIndex());
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
        internal void Gui_RenameLayer(int pLayerIndex, string pNewName) {
            EzJson j = new EzJson();
            j.BeginFunction("rename_layer");
            j.AddData("layer", pLayerIndex);
            j.AddData("name", pNewName);
            m_toolRunner.ParseJSON(j.Finish());
        }

        internal void Gui_CreateLayer() {
            EzJson j = new EzJson();
            j.BeginFunction("create_layer");
            m_toolRunner.ParseJSON(j.Finish());
        }
        internal void Gui_RemoveLayer( int pLayer) {
            EzJson j = new EzJson();
            j.BeginFunction("remove_layer");
            j.AddData("layer", pLayer);
            m_toolRunner.ParseJSON(j.Finish());
        }
        internal void Gui_SwapLayers(int pIndexA, int pIndexB) {
            Console.WriteLine("swap indices " + pIndexA + ", " + pIndexB);
            EzJson j = new EzJson();
            j.BeginFunction("swap_layers");
            j.AddData("layer", pIndexA);
            j.AddData("layer2", pIndexB);
            m_toolRunner.ParseJSON(j.Finish());
        }

        internal void SaveCanvasToFile(string pFileName) 
        {
            using (StreamWriter newTask = new StreamWriter(pFileName, false)) {
                
            }
            Console.WriteLine("trying to save file: " + pFileName);
        
        }

        internal Picture GetPicture() {
            return m_canvasWindow.GetPicture();
        }


    }
}
