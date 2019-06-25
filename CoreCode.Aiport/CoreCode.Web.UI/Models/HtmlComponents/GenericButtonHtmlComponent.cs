using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public class GenericButtonHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses { get; set; }

        public string GetCustomCssClasses => CustomCssClasses;

        public string ButtonValue { get; set; }
        public string Color { get; set; }
        public string HoverColor { get; set; }
    }
}