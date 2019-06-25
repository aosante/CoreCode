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

    public class AirlineController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/getAirlines")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirlineManagement();
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

        [Route("api/getWaitingAirlines")]
        public IHttpActionResult GetWaitingAirlines()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirlineManagement();
                apiResp.Data = mng.RetrieveWaitingAirlines();

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
        [Route("api/getAcceptedAirlines")]
        public IHttpActionResult GetAcceptedAirlines()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirlineManagement();
                apiResp.Data = mng.RetrieveAcceptedAirlines();

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
        [Route("api/getDeniedAirlines")]
        public IHttpActionResult GetDeniedAirlines()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirlineManagement();
                apiResp.Data = mng.RetrieveDeniedAirlines();

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

        [Route("api/getAvailableAirlines")]
        public IHttpActionResult GetAvailableAirlines()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirlineManagement();
                apiResp.Data = mng.RetrieveAvailableAirlines();

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

        [Route("api/getUnvailableAirlines")]
        public IHttpActionResult GetUnvailableAirlines()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirlineManagement();
                apiResp.Data = mng.RetrieveUnvailableAirlines();

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


        [Route("api/getAssociatedAirlines")]
        public IHttpActionResult getAssociatedAirlines(string id)
        {


            try
            {
                var mng = new AirlineManagement();
                var airline = new Airline
                {
                    Id = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAssociatedAirlines(airline);

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

        [Route("api/getRejectedAirlines")]
        public IHttpActionResult getRejectedAirlines(string id)
        {


            try
            {
                var mng = new AirlineManagement();
                var airline = new Airline
                {
                    Id = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveRejectedAirlines(airline);

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

        [Route("api/getAirlinesWaiting")]
        public IHttpActionResult getAirlinesWaiting(string id)
        {


            try
            {
                var mng = new AirlineManagement();
                var airline = new Airline
                {
                    Id = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveWaitingAirlines(airline);

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







        [Route("api/getAirlineById")]
        public IHttpActionResult Get(string Id)
        {
            try
            {
                var mng = new AirlineManagement();
                var airline = new Airline
                {
                    Id = Id
                };

                airline = mng.RetrieveById(airline);
                apiResp = new ApiResponse();
                apiResp.Data = airline;
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

        [Route("api/createAirline")]
        public IHttpActionResult Post(Airline airline)
        {

            try
            {
                var mng = new AirlineManagement();
                mng.Create(airline);

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
        [Route("api/updateAirline")]
        public IHttpActionResult Update(Airline airline)
        {
            try
            {
                var mng = new AirlineManagement();
                mng.Update(airline);

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
        [Route("api/deleteAirline")]
        public IHttpActionResult Delete(Airline airline)
        {
            try
            {
                var mng = new AirlineManagement();
                mng.Delete(airline);

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

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Retrieves the given airlines using airport by airport id </summary>
        ///
        /// <remarks>   Celopez</remarks>
        ///
        /// <param name="airline">  The airline to delete. </param>
        ///
        /// <returns>   An IHttpActionResult. </returns>
        ///-------------------------------------------------------------------------------------------------
        [Route("api/getAirlinesByAirportId")]
        public IHttpActionResult GetAirlinesByAirportId(string airportId)
        {
            try
            {
                var airlineManagement = new AirlineManagement();
                apiResp = new ApiResponse
                {
                    //Data = airlineManagement.GetAirlinesByAirportId(airportId),
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
    }
}
