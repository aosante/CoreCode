using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Web.UI.Models.HtmlComponents
{
    public interface IBaseHtmlComponent
    {
        string Id { get; set; }
        bool IsHidden { get; set; }
        string BoostrapClasses { get;set; }
        string CustomCssClasses { get; set; }
        string GetCustomCssClasses { get; }
    }
}
