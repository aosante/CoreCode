using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.Controls
{
    public class CtrlInputModel : CtrlBaseModel
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public string PlaceHolder { get; set; }
        public string ColumnDataName { get; set; }

        public CtrlInputModel()
        {
            ViewName = "";
        }
    }
}