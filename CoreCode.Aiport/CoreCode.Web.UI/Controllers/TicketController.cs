using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreCode.Web.UI.ActionFilter;
using Stripe;

namespace CoreCode.Web.UI.Controllers
{
    public class TicketController : Controller
    {
        [AllowCors]

        public ActionResult Index()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }

        //public ActionResult Charge(string stripeEmail, string stripeToken)
        //{
        //    var customers = new StripeCustomerService();
        //    var charges = new StripeChargeService();

        //    var customer = customers.Create(new StripeCustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        SourceToken = stripeToken
        //    });

        //    var charge = charges.Create(new StripeChargeCreateOptions
        //    {
        //        Amount = 500,//charge in cents
        //        Description = "Sample Charge",
        //        Currency = "usd",
        //        CustomerId = customer.Id
        //    });

        //    // further application specific code goes here

        //    return View();
        //}

        [Route("vTicket")]
        public ActionResult vTicket()
        {
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View();
        }

        [Route("CreateTicket")]
        public ActionResult CreateTicket()
        {
            return View();
        }

        [Route("ListTicket")]
        public ActionResult ListTicket()
        {
            return View();
        }
    }
}