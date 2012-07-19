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
            Dictionary<string, object>[] input = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>[]>(pJson);

            foreach (Dictionary<string, object> data in input) 
            {
                int layerIndex = Convert.ToInt32(data["layer"]);
                Layer layer = layers[layerIndex];
                int pressure = Convert.ToInt32(data["pressure"]);
                int x = Convert.ToInt32(data["x"]);
                int y = Convert.ToInt32(data["y"]);
                Tool tool = m_tools[data["tool"] as string];

                switch (data["function"] as string) 
                {
                    case "tool_down":
                        tool.Down(x, y, pressure, m_picture, layers[layerIndex], data["options"]);
                        break;
                    case "tool_move":
                        tool.Move(x, y, pressure, m_picture, layers[layerIndex]);
                        break;
                    case "tool_up":
                        tool.Up(x, y, pressure, m_picture, layers[layerIndex]);
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