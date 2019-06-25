using CoreCode.API.Core;
using CoreCode.Entities.POJO;
using CoreCodeAPI.Models;
using CoreCode.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreCodeAPI.ActionFilter;

namespace CoreCodeAPI.Controllers
{

    [AllowCors]

    public class FlightController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/getFlights")]
        public IHttpActionResult Get()
        {
            try
            {

                apiResp = new ApiResponse();
                var mng = new FlightManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
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

        [Route("api/getFlightById")]
        public IHttpActionResult Get(string Id)
        {
            try
            {
                var mng = new FlightManagement();
                var flight = new Flight
                {
                    Id = Id
                };

                flight = mng.RetrieveById(flight);
                apiResp = new ApiResponse();
                apiResp.Data = flight;
                return Ok(apiResp);
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
        [Route("api/getFlightOnTime")]
        public IHttpActionResult GetOnTime()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new FlightManagement();
                apiResp.Data = mng.flightsOnTime();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }

        }

        [Route("api/getFlightCanceled")]
        public IHttpActionResult GetCanceled()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new FlightManagement();
                apiResp.Data = mng.flightsCanceled();

                return Ok(apiResp);
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

        [Route("api/getFlightDelay")]
        public IHttpActionResult GetDelay()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new FlightManagement();
                apiResp.Data = mng.flightsDelay();

                return Ok(apiResp);
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

        // POST 

        [Route("api/createFlight")]
        public IHttpActionResult PostFlight(Flight flight)
        {

            try
            {
                var mng = new FlightManagement();
                mng.Create(flight);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
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

        // UPDATE
        [Route("api/updateFlight")]
        public IHttpActionResult Update(Flight flight)
        {
            try
            {
                var mng = new FlightManagement();
                mng.Update(flight);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
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

        // DELETE ==
        [Route("api/deleteFlight")]
        public IHttpActionResult Delete(Flight flight)
        {
            try
            {
                var mng = new FlightManagement();
                mng.Delete(flight);

                apiResp = new ApiResponse
                {
                    Message = "Action was executed."
                };

                return Ok(apiResp);
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


        ///[Route("api/getAirlinesByAirportId")]
        ///public IHttpActionResult GetAirlinesByAirportId(string airportId)
        ///{
        /// var airlineManagement = new AirlineManagement();
        /// apiResp = new ApiResponse
        /// {
        //Data = airlineManagement.GetAirlinesByAirportId(airportId),
        // Message = "Action was executed."
        // };
        //return Ok(apiResp);

        // }
    }
}
