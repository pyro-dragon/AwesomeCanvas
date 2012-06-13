using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AwesomeCanvas
{
    //-------------------------------------------------------------------------
    // Class for tracking the status of the mouse
    //-------------------------------------------------------------------------
    class MouseStatus
    {
        // Member variables
        bool LeftButtonDown { get;set; }
        bool RightButtonDown { get; set; }
        Point Position { get; set; }
    }
}
