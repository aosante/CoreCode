using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    public class AirportController : Controller
    {
        [Route("vListAirports")]
        public ActionResult vListAirports()
        {
            return View();
        }

        [Route("vCreateAirport")]
        public ActionResult vCreateAirport()
        {
            return View();
        }

    }
}