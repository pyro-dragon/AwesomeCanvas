using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace AwesomeCanvas
{
    internal class ZoomTool
    {
        bool m_zooming = false;
        PointF m_startDrag = PointF.Empty;
        
        CanvasWindow m_window = null;

        public ZoomTool(CanvasWindow pWindow) {
            m_window = pWindow;
        }
        public bool Enabled {
            get { return m_zooming; }
            set {
                m_zooming = value;
                if (m_zooming)
                    m_window.Cursor = Cursors.Cross;
                else
                    m_window.Cursor = Cursors.Arrow;
            }
        }
        public void Begin(Point pPoint) {
            m_startDrag = pPoint.ToPointF();
        }
        public void Move(Point pPoint) {
            PointF delta = pPoint.ToPointF().Subtract(m_startDrag);
            m_window.SetZoom(m_window.magnification + delta.X / 300f, true);
            m_startDrag = pPoint.ToPointF();
        }
    }
}
