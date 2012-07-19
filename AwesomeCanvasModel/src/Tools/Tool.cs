using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
namespace AwesomeCanvas
{
   

    public class Tool
    {
        public class Options { } //base class for all tool options
        public Tool(Controller pController)
        {
            m_controller = pController;
        }
        
        public bool isDown { get; private set; } //true when mouse is down

        protected virtual void SetOptions(Newtonsoft.Json.Linq.JContainer o) { options = o.ToObject<Options>(); } //!! virtual

        public virtual void Down(int pX, int pY, int pPressure, Picture pPicture, Layer pLayer, object pOptions) {
            isDown = true;
            m_lastPosition = new Point(pX, pY);
            m_lastPressure = pPressure;
            SetOptions(pOptions as Newtonsoft.Json.Linq.JContainer);
            m_layer = pLayer;
            m_picture = pPicture;
        }
        public virtual void Move(int pX, int pY, int pPressure) {}
        public virtual void Up(int pX, int pY, int pPressure) { isDown = false; }

        protected Options options;
        protected Layer m_layer;
        protected Picture m_picture;
        protected int m_lastPressure;
        protected Point m_lastPosition;
        protected Controller m_controller;      
    }
}