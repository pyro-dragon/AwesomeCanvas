using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AwesomeCanvas;
using System.IO;
using WintabDN;
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
            
            //setup first layer
            selectedLayerID = Gui_CreateLayer();
            Gui_ClearSelectedLayer();
            
            //add listeners for all functions that should redraw the main canvas
            m_toolRunner.AddFunctionListener( (pA, pB, pC) => { m_canvasWindow.Redraw(pA); }, "tool_down", "tool_up", "tool_move", "undo", "clear", "reorder_layers", "remove_layer");

            //add listeners for all functions that should rebuild the layer list
            m_toolRunner.AddFunctionListener((pA, pB, pC) => { m_layerControl.RebuildLayerControls(); }, "reorder_layers", "rename_layer", "remove_layer", "create_layer");
            
            //add listeners for all functions that should update a layer thumbnail
            m_toolRunner.AddFunctionListener((pA, pB, pC) => { m_layerControl.UpdateThumbnail(pC["layer"] as string); }, "tool_up", "undo", "clear");
            
            //add listeners for updating the status bar (:
            m_toolRunner.AddFunctionListener((pA, pB, pC) => { m_mainForm.SetStatus("last action: " + pB); }, "tool_down", "tool_up", "tool_move", "undo", "clear", "reorder_layers", "remove_layer", "create_layer");
        }

        internal void GuiInput_PointerUp(object sender, int x, int y, float pressure = 1.0f)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_up");
            j.AddData("x", (int)(x / m_canvasWindow.magnification));
            j.AddData("y", (int)(x / m_canvasWindow.magnification));
            j.AddData("pressure", pressure);
            j.AddData("layer", selectedLayerID);
            m_toolRunner.ParseJSON(j.Finish());
        }

        internal void GuiInput_PointerDown(object sender, int x, int y, float pressure = 1.0f)
        {
            string toolName = m_mainForm.GetToolName();
            EzJson j = new EzJson();
            j.BeginFunction("tool_down");
            j.AddData("pressure", (pressure).ToString());
            j.AddData("x", (int)(x / m_canvasWindow.magnification));
            j.AddData("y", (int)(x / m_canvasWindow.magnification));
            j.AddData("layer", selectedLayerID);
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

        internal void GuiInput_PointerMove(object sender, int x, int y, float pressure = 1.0f)
        {
            EzJson j = new EzJson();
            j.BeginFunction("tool_move");
            j.AddData("pressure", (pressure).ToString());
            j.AddData("x", (int)(x / m_canvasWindow.magnification));
            j.AddData("y", (int)(y / m_canvasWindow.magnification));
            m_toolRunner.ParseJSON(j.Finish());
        }

        //internal void GuiInput_TabletMove(object sender, WintabPacket pkt)
        //{
        //    EzJson j = new EzJson();
        //    j.BeginFunction("tool_move");
        //    j.AddData("pressure", pkt.pkNormalPressure.pkAbsoluteNormalPressure.ToString());
        //    j.AddData("x", (int)(pkt.pkX / m_canvasWindow.magnification));
        //    j.AddData("y", (int)(pkt.pkY / m_canvasWindow.magnification));
        //    m_toolRunner.ParseJSON(j.Finish());
        //}

        internal void Gui_Undo() {
            EzJson j = new EzJson();
            j.BeginFunction("undo");
            j.AddData("layer", selectedLayerID);
            m_toolRunner.ParseJSON(j.Finish());
            Console.WriteLine("undo!");
        }

        internal void Gui_ClearSelectedLayer() {
            EzJson j = new EzJson();
            j.BeginFunction("clear");
            j.AddData("layer", selectedLayerID);
            m_toolRunner.ParseJSON(j.Finish());

            Console.WriteLine("clear!");
        }
        internal void Gui_RenameLayer(string pLayerID, string pNewName) {
            EzJson j = new EzJson();
            j.BeginFunction("rename_layer");
            j.AddData("layer", pLayerID);
            j.AddData("name", pNewName);
            m_toolRunner.ParseJSON(j.Finish());
        }

        internal string Gui_CreateLayer() {
            string id = Guid.NewGuid().ToString(); //create a globally unique id
            EzJson j = new EzJson();
            j.BeginFunction("create_layer");
            j.AddData("layer", id);
            m_toolRunner.ParseJSON(j.Finish());
            return id;
        }
        internal void Gui_RemoveLayer( string pLayerID) {
            EzJson j = new EzJson();
            j.BeginFunction("remove_layer");
            j.AddData("layer", pLayerID);
            m_toolRunner.ParseJSON(j.Finish());
        }
        internal void Gui_SetLayerOrder(string[] pOrderedIDs) {
            EzJson j = new EzJson();
            j.BeginFunction("reorder_layers");
            j.AddData("order", pOrderedIDs);
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



        public string selectedLayerID { get; set; }
    }
}
