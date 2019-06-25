using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoreCode.Web.UI.Controllers
{
    public class AiportManagerController : Controller
    {
        // GET: AiportManager
        [Route("airportManager")]
        public ActionResult Index()
        {
            return View("AirportManager");
        }

        [Route("vCreateAirportAdmin")]
        public ActionResult vCreateAirportAdmin()
        {
            return View();
        }

     

        [Route("vRequestAdminAirportFromAirline")]
        public ActionResult vRequestAdminAirportFromAirline()
        {
            return View();
        }


        [Route("vEditAirportAdmin")]
        public ActionResult vEditAirportAdmin()
        {
            return View();
        }


    }
}