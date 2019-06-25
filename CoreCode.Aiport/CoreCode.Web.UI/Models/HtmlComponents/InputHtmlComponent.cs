using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public class InputHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses { get; set; }
        public string GetCustomCssClasses { get; }
        public string Type { get; set; }
        public string PlaceHolder { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public string IdLabel { get; set; }
        public string LabelCssClasses { get; set; }
        public string ColumnDataName { get; set; }
        public bool IsDisabled { get; set; }
    }
}