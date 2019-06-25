using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreCode.Web.UI.Models.ViewComponents;

namespace CoreCode.Web.UI.Controllers
{
    public class DashboardController : Controller
    {
        private const string DashboardAsideNavigationNameRoute = "DashboardAsideNavigation";
        private const string CreateCategoryHtmlRoute = "~/Views/PartialViews/CustomComponentContent/CreateCategory.cshtml";
        private const string ListCategoriesHtmlRoute = "~/Views/PartialViews/CustomComponentContent/ListCategories.cshtml";
        private const string EditAirportHtmlRoute = "~/Views/PartialViews/CustomComponentContent/EditAirport.cshtml";
        private const string CreateStoreHtmlRoute = "~/Views/PartialViews/CustomComponentContent/CreateStorePartial.cshtml";
        private const string ViewAirportsHtmlRoute = "~/Views/PartialViews/CustomComponentContent/ViewAirports.cshtml";
        private const string ViewStoresHtmlRoute = "~/Views/PartialViews/CustomComponentContent/ViewStores.cshtml";
        private const string ViewGatesHtmlRoute = "~/Views/PartialViews/CustomComponentContent/ViewGates.cshtml";
        private const string AddGatesHtmlRoute = "~/Views/PartialViews/CustomComponentContent/AddGate.cshtml";
        private const string ViewAirlinesHtmlRoute = "~/Views/PartialViews/CustomComponentContent/ViewAirlines.cshtml";
        // GET: Dashboard
        [Route("dashboard/airport/{airportId}")]
        public ActionResult ShowAirportDashboard(string airportId)
        {
            return View();
        }

        [Route("dashboard/airline/{airlineId}")]
        public ActionResult ShowAirlineDashboard(string airlineId)
        {
            return View();
        }

        [Route("dashboard/general")]
        public ActionResult ShowGeneralDashboard(string airportId)
        {
            return View();
        }


        [Route("getDashboardAsideNav")]
        public ActionResult DashboardAsideNavigation()
        {
            return PartialView(DashboardAsideNavigationNameRoute);
        }

        [Route("getCreateCategoryHtml")]
        public ActionResult GetCreateCategoryHtml()
        {
            return PartialView(CreateCategoryHtmlRoute);
        }

        [Route("getListCategoriesHtml")]
        public ActionResult GetListCreateCategoryHtml()
        {
            return PartialView(ListCategoriesHtmlRoute );
        }
        
        [Route("getEditAirportHtml")]
        public ActionResult GetEditAirportHtmlListCreateCategoryHtml()
        {
            return PartialView(EditAirportHtmlRoute );
        }

        [Route("getCreateStoreHtml")]
        public ActionResult GetCreateStoreHtml()
        {
            var viewComponent = new CreateStoreComponent()
            {
                ViewName = "CreateStore"
            };
            return PartialView(CreateStoreHtmlRoute, viewComponent);
        }

        [Route("getViewAirportsHtml")]
        public ActionResult GetViewAirportsHtml()
        {
            return PartialView(ViewAirportsHtmlRoute);
        }

        [Route("getViewStoresHtml")]
        public ActionResult GetViewStoresHtml()
        {
            return PartialView(ViewStoresHtmlRoute);
        }

        [Route("getAddGateHtml")]
        public ActionResult GetAddGatesHtml()
        {
            return PartialView(AddGatesHtmlRoute);
        }

        [Route("getViewGatesHtml")]
        public ActionResult GetViewGatesHtml()
        {
            return PartialView(ViewGatesHtmlRoute);
        }

        [Route("getViewAirlinesHtml")]
        public ActionResult GetViewAirlinesHtml()
        {
            return PartialView(ViewAirlinesHtmlRoute);
        }
    }
}