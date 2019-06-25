using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CoreCode.Web.UI.Models.Controls
{
    public class CtrlBaseModel
    {
        public string Id { get; set; }
        public string ViewName { get; set; }

        private string ReadFileText()
        {
            //C:\Users\Andres Osante\Desktop\Desktop\cenfo_proyecto_2_2019_01\Capa WEB\Components\WebApp\Models\Controls
            string path = System.Configuration.ConfigurationManager.AppSettings["PathTemplates"];
            string fileName = this.GetType().Name + ".html";

            path = Path.Combine(path, fileName);

            string text = File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop != null)
                {
                    var value = prop.GetValue(this, null).ToString();

                    var tag = string.Format("-#{0}-", prop.Name);
                    html = html.Replace(tag, value);
                }
            }
            return html;
        }
    }
}