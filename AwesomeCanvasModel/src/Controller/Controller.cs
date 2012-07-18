using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AwesomeCanvas
{
    public delegate void ControllerEventHandler( Controller pTarget );
    public class Controller
    {

        public ControllerEventHandler OnCanvasNeedsRedraw;
        //public
        Picture m_picture;
        string m_username;
        Dictionary<string, Tool> m_tools = new Dictionary<string, Tool>();
        public Controller( string pUsername, Picture pPicture) {
            m_tools.Add("brush", new BrushTool(this));
            m_tools.Add("pen", new PenTool(this));
            m_tools.Add("pointer", new PointerTool(this));
            m_username = pUsername;
            m_picture = pPicture;
        }
        
       // Decypher the JSON command and execute the corrasponding function
        public void ParseJSON(string pJson) {
            if (m_picture == null)
                return;
            //Console.WriteLine(pJson);
            Dictionary<string, string>[] input = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>[]>( pJson );

            foreach (Dictionary<string, string> data in input) 
            {
                int layerIndex = Convert.ToInt32(data["layer"]);
                Layer layer = layers[layerIndex];
                int size = Convert.ToInt32(data["size"]);
                int x = Convert.ToInt32(data["x"]);
                int y = Convert.ToInt32(data["y"]);
                Tool tool = m_tools[data["tool"]];

                switch (data["function"]) 
                {
                    case "tool_down":
                        tool.Down(x, y, size, m_picture, layers[layerIndex]);
                        break;
                    case "tool_move":
                        tool.Move(x, y, size, m_picture, layers[layerIndex]);
                        break;
                    case "tool_up":
                        tool.Up(x, y, size, m_picture, layers[layerIndex]);
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
                OnCanvasNeedsRedraw(this);
            }
        }
        public List<Layer> layers { 
            get 
            {
                return m_picture.layers; 
            } 
        }        
    }
}