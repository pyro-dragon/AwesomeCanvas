using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AwesomeCanvas
{
    public delegate void ControllerEventHandler( Controller pTarget );
    public class Controller
    {
        public const string DEFAULT_TOOL = "pointer";
        public ControllerEventHandler OnToolSizeChanged;
        //public event ControllerEventHandler OnToolChanged;
        //public event ControllerEventHandler OnColorChanged;
        public ControllerEventHandler OnCanvasUpdated;
        //public

        Picture m_picture;
        int m_currentLayer;
        string m_username;
        Dictionary<string, Tool> m_tools = new Dictionary<string, Tool>();
        public Tool currentTool{get; private set;}
        public Controller( string pUsername, Picture pPicture) {
            
            m_tools.Add("brush", new BrushTool(this));
            m_tools.Add("pen", new PenTool(this));
            m_tools.Add(DEFAULT_TOOL, new PointerTool(this));

            currentTool = m_tools[DEFAULT_TOOL];
            m_username = pUsername;
            m_picture = pPicture;
            m_currentLayer = 0;
   
        }
        
       // Decypher the JSON command and execute the corrasponding function
        public void ParseJSON(string pJson) {
            //Console.WriteLine(pJson);
            Dictionary<string, string>[] input = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>[]>( pJson );
            foreach (Dictionary<string, string> data in input) 
            {
                switch (data["function"]) 
                {
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

                    //case "change_layer": 

                    //    break;

                    //case "new_layer": 

                    //    break;

                    //case "delete_layer": 

                    //    break;

                    default: 
                        break;
                }
            }
        }
        public Layer currentLayer { 
            get 
            { 
                if (m_picture != null && m_picture.layers.Count > m_currentLayer && m_picture.layers.Count > 0) 
                { 
                    return m_picture.layers[m_currentLayer]; 
                } 

                return null; 
            } 
        }
        void ChangeTool( Dictionary<string,string> pOptions )
        {
            string toolName;
            Tool oldTool = currentTool;
            Tool newTool = null;
            toolName = pOptions["tool"];
            if (m_tools.TryGetValue(toolName, out newTool)) 
            {
                if (oldTool != null && oldTool.isActive)
                    oldTool.Deactivate();
                currentTool = newTool;
                currentTool.Activate();
                if (OnToolSizeChanged != null)
                    OnToolSizeChanged(this);
                Console.WriteLine("Changed tool to " + toolName);
            }
            else 
                throw new Exception("no tool named toolName");
        }
        void ToolDown(Dictionary<string, string> pOptions) 
        {
            if (currentLayer != null )
                currentTool.Down(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), m_picture, currentLayer);
        }
        void ToolMove(Dictionary<string, string> pOptions) 
        {
            if (currentTool != null && currentLayer != null) 
            {
                currentTool.Move(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), m_picture, currentLayer);
                if (OnCanvasUpdated != null)
                    OnCanvasUpdated(this);
            }
        }
        void ToolUp(Dictionary<string, string> pOptions) 
        {
            if (currentLayer != null)
                currentTool.Up(Convert.ToInt32(pOptions["x"]), Convert.ToInt32(pOptions["y"]), m_picture, currentLayer);
        }
        void ToolSize(Dictionary<string, string> pOptions) 
        {
            currentTool.size = Convert.ToInt32(pOptions["size"]);
            if(OnToolSizeChanged != null)
                OnToolSizeChanged(this);
        }
    }
}