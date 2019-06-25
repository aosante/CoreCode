using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public class BigModalHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses { get; set; }
        public string GetCustomCssClasses => string.Empty;
        public string PartialPathToRenderContent { get; set; }
        public string Title { get; set; }
        public bool ShowGenericCloseButtons { get;set; }

    }
}