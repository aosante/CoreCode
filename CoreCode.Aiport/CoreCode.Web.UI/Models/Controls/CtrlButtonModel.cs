using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.Controls
{
    public class CtrlButtonModel: CtrlBaseModel
    {
        public string Label { get; set; }
        public string FunctionName { get; set; }
        public string ButtonType { get; set; }

        public CtrlButtonModel()
        {
            ViewName = "";
        }
    }
}