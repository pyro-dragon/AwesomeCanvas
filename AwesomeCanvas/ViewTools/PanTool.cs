using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AwesomeCanvas
{
    internal class PanTool
    {
        bool m_panning = false;
        CanvasWindow m_window = null;
        Point m_panPosition = Point.Empty;
        public PanTool(CanvasWindow pWindow) {
            m_window = pWindow;
        }
        public bool Enabled {
            get { return m_panning; }
            set {
                m_panning = value;
                if (m_panning)
                    m_window.Cursor = Cursors.Hand;
                else
                    m_window.Cursor = Cursors.Arrow;
            }
        }
        public void Begin(Point pPoint) {
            m_panPosition = pPoint;
        }
        public void Move(Point pPoint) {
            Point panDelta = pPoint.Subtract(m_panPosition);
            m_window.SetPanPosition(m_window.GetPanPosition().Add(panDelta));
        }
    }
}
