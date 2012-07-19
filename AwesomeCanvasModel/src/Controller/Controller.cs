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
        
        Picture m_picture;
        string m_username;
        Dictionary<string, Tool> m_tools = new Dictionary<string, Tool>();
        Tool m_currentTool = null;

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
                //so far all commands contains these three parameters
                int pressure = Convert.ToInt32(data["pressure"]);
                int x = Convert.ToInt32(data["x"]);
                int y = Convert.ToInt32(data["y"]);

                switch (data["function"] as string) 
                {
                    case "tool_down": //tool down comes with all the tool options
                        Tool tool = m_tools[data["tool"] as string]; //swap tool on tool down
                        int layerIndex = Convert.ToInt32(data["layer"]);
                        Layer layer = layers[layerIndex];
                        m_currentTool = tool;
                        m_currentTool.Down(x, y, pressure, m_picture, layer, data["options"]);
                        break;
                    case "tool_move":
                        if(m_currentTool != null) //tool move can happend without tool beeing down
                            m_currentTool.Move(x, y, pressure);
                        break;
                    case "tool_up":
                        if (m_currentTool != null)//tool up might happend without tool beeing down
                            m_currentTool.Up(x, y, pressure);
                        //release tool
                        m_currentTool = null;
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