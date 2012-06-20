using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeCanvas.Application.Controller;
namespace AwesomeCanvas
{
    class PointerTool : Tool
    {
        public PointerTool(Controller pController) : base(pController)
        {
            size = 0;
        }
    }
}
