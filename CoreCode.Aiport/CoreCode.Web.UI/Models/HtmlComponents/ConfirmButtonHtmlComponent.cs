using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public class ConfirmButtonHtmlComponent : IBaseHtmlComponent
    {
        public string Id { get; set; }
        public bool IsHidden { get; set; }
        public string BoostrapClasses { get; set; }
        public string CustomCssClasses {get; set; }
        public string ButtonValue {get; set; }
        public string ScriptInstanceName { get; set; }
        public string ScriptFunction { get; set; }
        public string GetCustomCssClasses => string.IsNullOrEmpty(CustomCssClasses) ? string.Empty : CustomCssClasses;
        public string ScriptParameters {get; set; }
        public ConfirmButtonHtmlComponent(string htmlId, string boostrapClasses, string extraClasses = "", bool isHidden = false)
        {
            Id = htmlId;
            BoostrapClasses = boostrapClasses;
            CustomCssClasses  = extraClasses;
            IsHidden = isHidden;
        }
    }
}