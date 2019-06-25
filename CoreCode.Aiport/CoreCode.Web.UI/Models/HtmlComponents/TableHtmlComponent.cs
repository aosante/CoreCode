using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    
    public class TableHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses { get; set; }
        public string GetCustomCssClasses { get; }
        public string TableTitle { get; set; }
        public string ViewName {get; set; }
        public string OnSelectFunctionName {get; set; }
        public List<string> TableHeaderColumns { get; set; }
        public List<string> Columns { get; set; }
        

    }
}