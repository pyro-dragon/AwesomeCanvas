using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace AwesomeCanvas
{
    // The base object for tools
    public class Tool
    {
        public const int DEFAULT_TOOLSIZE = 14;

        public Tool(Controller pController)
        {
            m_controller = pController;
        }
        public bool isDown { get; private set; } //true when mouse is down
        public virtual void Down(int pX, int pY, int pSize, Picture pPicture, Layer pLayer) { 
            isDown = true; 
            m_lastPosition = new Point(pX, pY);
            m_lastSize = pSize;
        }
        public virtual void Move(int pX, int pY, int pSize, Picture pPicture, Layer pLayer) {}
        public virtual void Up(int pX, int pY, int pSize, Picture pPicture, Layer pLayer) { isDown = false; }

        protected int m_lastSize;
        protected Point m_lastPosition;
        protected Controller m_controller;      
    }
}