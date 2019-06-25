using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public class ModalHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses { get; set; }
        public string GetCustomCssClasses => "";
        public HtmlString ModalContent { get; set; }
    }
}