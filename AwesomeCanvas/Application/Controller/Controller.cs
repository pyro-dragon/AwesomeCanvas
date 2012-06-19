using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AwesomeCanvas.Application.Controller
{
    public class Controller
    {
        Picture m_picture;
        int m_currentLayer;
        string m_username;
        Dictionary<string, Tool> m_tools = new Dictionary<string, Tool>();
        Tool m_activeTool;
        public Controller( string pUsername ) {
            m_tools.Add("brush", new BrushTool());
            m_tools.Add("pointer", new PointerTool());
            m_username = pUsername;
        }
        
        public void SetPicture(Picture pPicture) {
            m_picture = pPicture;
            m_currentLayer = 0;
        }
        
        public void ParseJSON(string pJson) {
            //Console.WriteLine(pJson);
            Dictionary<string, string>[] input = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>[]>( pJson );
            foreach (Dictionary<string, string> data in input) 
            {
                switch (data["function"]) {
                    case "change_tool":
                    ChangeTool(data);
                    break;
                    case "tool_down":
                    ToolDown(data);
                    break;
                    case "tool_move":
                    ToolMove(data);
                    break;
                    case "tool_up":
                    ToolUp(data);
                    break;
                    case "tool_size":
                    ToolSize(data);
                    break;
                    default: break;
                }
            }
        }
        Layer currentLayer { get { if (m_picture != null && m_picture.layers.Count > m_currentLayer && m_picture.layers.Count > 0) { return m_picture.layers[m_currentLayer]; } return null; } }
        void ChangeTool( Dictionary<string,string> pOptions ){
            string toolName;
            Tool oldTool = m_activeTool;
            toolName = pOptions["tool"];
            if(m_tools.TryGetValue(toolName, out m_activeTool)){
                if (oldTool != null && oldTool.isActive)
                    oldTool.Deactivate();
                m_activeTool.Activate();
                Console.WriteLine("Changed tool to " + toolName);
            }
        }
        void ToolDown(Dictionary<string, string> pOptions) {
            if (m_activeTool != null && currentLayer != null )
                m_activeTool.Down(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), m_picture, currentLayer);
        }
        void ToolMove(Dictionary<string, string> pOptions) {
            if (m_activeTool != null && currentLayer != null)
                m_activeTool.Move(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), m_picture, currentLayer);
        }
        void ToolUp(Dictionary<string, string> pOptions) {
            if (m_activeTool != null && currentLayer != null)
                m_activeTool.Up(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), m_picture, currentLayer);
        }
        void ToolSize(Dictionary<string, string> pOptions) {
            if (m_activeTool != null)
                m_activeTool.size = Convert.ToInt32(pOptions["size"]);
        }
    }
}