using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeCanvas;
namespace AwesomeCanvas
{
    class PointerTool : Tool
    {
        protected override void SetOptions(Newtonsoft.Json.Linq.JContainer o) {
            
        }
        public PointerTool(ToolRunner pController) : base(pController)
        {
        }
    }
}
