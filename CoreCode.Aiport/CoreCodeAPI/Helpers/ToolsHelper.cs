using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace CoreCodeAPI.Helpers
{
    public  class ToolsHelper
    {

        public static bool SendMail(string correo, string titulo, string mensaje)
        {
            var resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("internationalaholding@gmail.com");
                mail.Subject = titulo;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new System.Net.NetworkCredential("internationalaholding@gmail.com", "coreCode12345"),
                    Host= "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                smtp.Send(mail);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }
            return resultado;

        }
        public static string UrlOriginal(HttpRequestBase request)
        {
            string hostHeader = request.Headers["host"];
            //string.Format("{0}://{1}{2}",
            //   request.Url.Scheme,
            //   hostHeader,
            //   request.RawUrl);
            return string.Format("{0}://{1}",
               request.Url.Scheme,
               hostHeader);
        }
    }
}
