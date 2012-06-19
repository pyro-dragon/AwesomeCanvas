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
        public Tool(){
            size = DEFAULT_TOOLSIZE;
        }
        public bool isDown { get; private set; } //true when mouse is down
        public bool isActive { get; private set; } //true when tool is in the hand of the controller
        public virtual void Activate() { isActive = true;   }
        public virtual void Deactivate() { isActive = false; }
        public virtual void Down(int pX, int pY, Picture pPicture, Layer pLayer) { isDown = true; m_lastPosition = m_postion = new Point(pX, pY); }
        public virtual void Move(int pX, int pY, Picture pPicture, Layer pLayer) { }
        public virtual void Up(int pX, int pY, Picture pPicture, Layer pLayer) { isDown = false; }

        private int m_size;
        protected Rectangle m_toolArea;
        protected int m_halfSquared, m_halfSize;
        protected Point m_postion, m_lastPosition;

        public int size {
            set {
                m_size = value;
                m_halfSize = m_size / 2;
                m_toolArea.Height = m_size;
                m_toolArea.Width = m_size;
                m_halfSquared = m_halfSize * m_halfSize;
            }
        }
        //-------------------------------------------------------------------------
        // Get methods
        //-------------------------------------------------------------------------
        public int GetSize() { return m_size; }
        public int GetHalfSize() { return m_size; }
        public Rectangle GetToolArea() { return m_toolArea; }
    }
}