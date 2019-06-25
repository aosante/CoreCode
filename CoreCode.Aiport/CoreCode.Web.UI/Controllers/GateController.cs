using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    public class GateController : Controller
    {

        [Route("vGates")]
        public ActionResult vGates()
        {
            return View();
        }

        

       
    }
}