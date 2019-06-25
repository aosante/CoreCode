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
    public class AirportController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/getAirports")]
        public IHttpActionResult Get()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirportManagement();
                apiResp.Data = mng.RetrieveAll();

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {

                var MessageManage = new ApplicationMessageManagement();
                MessageManage.Create(bex.AppMessage);

                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));

            }
            catch (Exception ex)
            {

                var appMessage = new ApplicationMessage();
                var MessageManage = new ApplicationMessageManagement();

                appMessage.Message = ex.Message;
                MessageManage.Create(appMessage);

                return InternalServerError(new Exception(appMessage.Message));
            }


        }


        [Route("api/getAvailableAirports")]
        public IHttpActionResult GetAvailables()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirportManagement();
                apiResp.Data = mng.RetrieveAvailable();

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
        [Route("api/getUnavailableAirports")]
        public IHttpActionResult GetUnavailables()
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new AirportManagement();
                apiResp.Data = mng.RetrieveUnavailable();

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

        [Route("api/getAssociatedAirports")]
        public IHttpActionResult GetAssociatedAirports(string id)
        {


            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveAssociatedAirports(airport);

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

        [Route("api/getNonAssociatedAirports")]
        public IHttpActionResult GetNonAssociatedAirports(string id)
        {


            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };
                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrieveNonAssociatedAirports(airport);

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

        [Route("api/getPossibleDestinyAirports")]
        public IHttpActionResult GetPossibleDestinyAirports(RequestAirlineAirport rqaa)
        {


            try
            {
                var mng = new AirportManagement();

                apiResp = new ApiResponse();
                apiResp.Data = mng.RetrievePossibleDestinyAirports(rqaa);

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





        [Route("api/getAirportById")]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };

                airport = mng.RetrieveById(airport);
                apiResp = new ApiResponse();
                apiResp.Data = airport;
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

        [Route("api/getAirportStores")]
        public IHttpActionResult GetStores(string id)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };

                List<Store> list = mng.RetrieveStores(airport);
                apiResp = new ApiResponse();
                apiResp.Data = list;
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

        [Route("api/getAvailableArptGates")]
        public IHttpActionResult GetAvailableAirportGates(string id)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };

                List<Gate> list = mng.RetrieveAvailableGates(airport);
                apiResp = new ApiResponse();
                apiResp.Data = list;
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

        [Route("api/getUnavailableArptGates")]
        public IHttpActionResult GetUnavailableAirportGates(string id)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };

                List<Gate> list = mng.RetrieveUnavailableGates(airport);
                apiResp = new ApiResponse();
                apiResp.Data = list;
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




        [Route("api/getAirportGates")]
        public IHttpActionResult GetGates(string id)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    ID = id
                };

                List<Gate> list = mng.RetrieveGates(airport);
                apiResp = new ApiResponse();
                apiResp.Data = list;
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
        // CREATE
        [Route("api/postAirport")]
        public IHttpActionResult Post(Airport airport)
        {

            try
            {
                var mng = new AirportManagement();
                mng.Create(airport);

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

        // PUT
        // UPDATE
        [Route("api/updateAirport")]
        public IHttpActionResult UpdateAirport(Airport airport)
        {
            try
            {
                var mng = new AirportManagement();
                mng.Update(airport);

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
        [Route("api/deleteAirport")]
        public IHttpActionResult Delete(String id)
        {

            try
            {
                var airport = new Airport
                {
                    ID = id
                };
                var mng = new AirportManagement();
                mng.Delete(airport);

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
    }
}
