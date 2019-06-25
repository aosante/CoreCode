using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreCode.Web.UI.ActionFilter;

namespace CoreCode.Web.UI.Controllers
{
    [AllowCors]
    public class CategoryController : Controller
    {

        [Route("vCategories")]
        public ActionResult vCategories()
        {
            return View();
        }
        

    }
}