using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public class SelectDropdownHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses { get; set; }
        public string GetCustomCssClasses => CustomCssClasses;
        public Dictionary<string, string> OptionList { get; set; }
        public string ViewName { get; set; }
        public string OnChangeFunction { get; set; }
        public string ColumnDataName { get; set; }
        public string OnLoadFunction { get; set; }
    }
}