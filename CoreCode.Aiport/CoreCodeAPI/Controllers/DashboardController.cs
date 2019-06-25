using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CoreCode.API.Core;
using CoreCode.API.Core.Managers;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.ActionFilter;
using CoreCodeAPI.Models;

namespace CoreCodeAPI.Controllers
{
    [AllowCors]
    public class DashboardController : ApiController
    {
        [Route("api/dashboard/getGeneralReport")]
        public IHttpActionResult GetGeneralReport(string airportId)
        {
            try
            {
                var generalReportManager = new GeneralReportManager();
                var apiResponse = new ApiResponse
                {
                Message = "Executed",
                    Data = generalReportManager.RetrieveReport(airportId)
                };
                return Ok(new { Result = apiResponse });
            }
            catch (BussinessException bex)
            {

                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(bex.AppMessage);
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
            catch (Exception ex)
            {
                ApplicationMessage msg = new ApplicationMessage
                {
                    Message = ex.Message
                };
                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(msg);
                return InternalServerError(new Exception(ex.Message));
            }

        }

        [Route("api/dashboard/getGeneralAdminReport")]
        public IHttpActionResult GetGeneralAdminReport()
        {
           
            var reportManager = new GeneralAdminReportManager();
            var apiResponse = new ApiResponse
            {
                Message = "Executed",
                Data = reportManager.RetrieveReport()
            };
            return Ok(new {Result = apiResponse});
        }

        [Route("api/dashboard/getAirlineAdminReport")]
        public IHttpActionResult GetAirlineAdminReport(string airlineId)
        {
            var reportManager = new AirlineReportManager();
            var apiResponse = new ApiResponse
            {
                Message = "Executed",
                Data = reportManager.RetrieveReport(airlineId)
            };
            return Ok(new {Result = apiResponse});
        }

    }
}