using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
namespace AwesomeCanvas
{
    // The base object for tools
    public class ToolOptions {
    }
    public class Tool
    {
        public const int DEFAULT_TOOLSIZE = 14;

        public Tool(Controller pController)
        {
            m_controller = pController;
        }
        
        public bool isDown { get; private set; } //true when mouse is down
        
        public virtual void Down(int pX, int pY, int pPressure, Picture pPicture, Layer pLayer, object pOptions) { 
            isDown = true; 
            m_lastPosition = new Point(pX, pY);
            m_lastPressure = pPressure;
            SetOptions(pOptions as Newtonsoft.Json.Linq.JContainer);
        }
        protected virtual void SetOptions(Newtonsoft.Json.Linq.JContainer o) { options = o.ToObject<ToolOptions>(); } //!! virtual
        public virtual void Move(int pX, int pY, int pPressure, Picture pPicture, Layer pLayer) {}
        public virtual void Up(int pX, int pY, int pPressure, Picture pPicture, Layer pLayer) { isDown = false; }

        protected ToolOptions options;
        protected int m_lastPressure;
        protected Point m_lastPosition;
        protected Controller m_controller;      
    }
}