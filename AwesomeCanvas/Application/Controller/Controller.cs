using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AwesomeCanvas.Application.Controller
{
    public class Controller
    {
        Picture _picture;
        int _currentLayer;
        string _username;
        Dictionary<string, Tool> _tools = new Dictionary<string, Tool>();
        Tool _activeTool;
        public Controller( string pUsername ) {
            _tools.Add("brush", new BrushTool());
            _tools.Add("pointer", new PointerTool());
            _username = pUsername;
        }
        
        public void SetPicture(Picture pPicture) {
            _picture = pPicture;
            _currentLayer = 0;
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
                    default: break;
                }
            }
        }
        Layer currentLayer { get { if (_picture != null && _picture.layers.Count > _currentLayer && _picture.layers.Count > 0) { return _picture.layers[_currentLayer]; } return null; } }
        void ChangeTool( Dictionary<string,string> pOptions ){
            string toolName;
            Tool oldTool = _activeTool;
            toolName = pOptions["tool"];
            if(_tools.TryGetValue(toolName, out _activeTool)){
                if (oldTool != null && oldTool.active)
                    oldTool.Deactivate();
                _activeTool.Activate();
                Console.WriteLine("Changed tool to " + toolName);
            }
        }
        void ToolDown(Dictionary<string, string> pOptions) {
            if (_activeTool != null && _picture != null && currentLayer != null )
                _activeTool.Down(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), _picture, currentLayer);
        }
        void ToolMove(Dictionary<string, string> pOptions) {
            if (_activeTool != null && _picture != null && currentLayer != null)
                _activeTool.Move(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), _picture, currentLayer);
        }
        void ToolUp(Dictionary<string, string> pOptions) {
            if (_activeTool != null && _picture != null && currentLayer != null)
                _activeTool.Up(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), _picture, currentLayer);
        }
    }
}