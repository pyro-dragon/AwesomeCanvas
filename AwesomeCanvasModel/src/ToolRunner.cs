﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AwesomeCanvas
{
    public delegate void ToolRunnerEventHandler( ToolRunner pTarget );
    public class ToolRunner
    {
        public ToolRunnerEventHandler OnCanvasNeedsRedraw;
        Picture m_picture;
        string m_username;
        Dictionary<string, Tool> m_tools = new Dictionary<string, Tool>();
        
        Tool m_currentTool = null; //when making strokes we cache these for optimization
        Layer m_currentLayer = null; //when making strokes we cache these for optimization

        public ToolRunner( string pUsername, Picture pPicture) {
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
            ExecuteCommands(input);
            OnCanvasNeedsRedraw(this);
        }
        void ToolDown(Dictionary<string, object> inputMessage) {
            int pressure = Convert.ToInt32(inputMessage["pressure"]);
            int x = Convert.ToInt32(inputMessage["x"]);
            int y = Convert.ToInt32(inputMessage["y"]);
            Tool tool = m_tools[inputMessage["tool"] as string]; //swap tool on tool down
            int layerIndex = Convert.ToInt32(inputMessage["layer"]);
            m_currentLayer = layers[layerIndex];
            m_currentTool = tool;
            m_currentTool.Down(x, y, pressure, m_picture, m_currentLayer, inputMessage["options"]);
            m_currentLayer.History.BeginNewUndoLevel();
            m_currentLayer.History.StoreUndoData(inputMessage);
        }
        void ToolMove(Dictionary<string, object> inputMessage) {
            int pressure = Convert.ToInt32(inputMessage["pressure"]);
            int x = Convert.ToInt32(inputMessage["x"]);
            int y = Convert.ToInt32(inputMessage["y"]);
            m_currentTool.Move(x, y, pressure);
            m_currentLayer.History.StoreUndoData(inputMessage);
        }
        void ToolUp(Dictionary<string, object> inputMessage) {
            int pressure = Convert.ToInt32(inputMessage["pressure"]);
            int x = Convert.ToInt32(inputMessage["x"]);
            int y = Convert.ToInt32(inputMessage["y"]);
            m_currentTool.Up(x, y, pressure);
            m_currentLayer.History.StoreUndoData(inputMessage);
            m_currentTool = null;
            m_currentLayer = null;        
        }
        void ExecuteCommands(IEnumerable<Dictionary<string, object>> input) 
        {
            foreach (Dictionary<string, object>inputMessage in input) 
            {

                switch (inputMessage["function"] as string) 
                {
                    case "tool_down": //tool_down comes with all the tool options
                    ToolDown(inputMessage);
                    break;
                    case "tool_move":
                    if (m_currentTool != null) //tool_move can happend without tool beeing down
                        ToolMove(inputMessage);
                    break;
                    case "tool_up":
                    if (m_currentTool != null) //tool_up can happend without tool beeing down
                        ToolUp(inputMessage);
                    break;
                    case "clear":
                    m_picture.Clear();
                    break;
                    case "undo":
                    int layerIndex = Convert.ToInt32(inputMessage["layer"]);
                    Layer l = layers[layerIndex];
                    m_picture.Clear();
                    l.History.PopUndoLevel();
                    Dictionary<string,object>[] h = l.History.ToArray();//important to copy to array since the history will be modified!
                    l.History.Clear();
                    ExecuteCommands(h);
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
        public List<Layer> layers { 
            get 
            {
                return m_picture.layers; 
            } 
        }        
    }
}