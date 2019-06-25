using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    
    public class StoreController : Controller
    {
        [Route("CreateStore")]
        public ActionResult CreateStore()
        {
            return View();
        }

        [Route("ListStore")]
        public ActionResult ListStore()
        {
            return View();
        }
        [Route("EditStore")]
        public ActionResult EditStore()
        {
            return View();
        }
    }
}