using CoreCode.API.Core;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.ActionFilter;
using CoreCodeAPI.Helpers;
using CoreCodeAPI.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace CoreCodeAPI.Controllers
{

    [AllowCors]
    public class AirportManagerController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();
        AirportManagerManagement mng = new AirportManagerManagement();

        [Route("api/getAirportManagers")]
        public IHttpActionResult Get()
        {
            try
            {
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

        public IHttpActionResult Get(string id)
        {
            try
            {
                var airportManager = new AirportManager
                {
                    ID = id
                };

                airportManager = mng.RetrieveById(airportManager);
                apiResp.Data = airportManager;
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

        [Route("api/postAirportManager")]
        public IHttpActionResult Post(AirportManager manager)
        {
            try
            {
                var CorreoElectronico = manager.Email;
                var pass = manager.Password;
                mng.Create(manager);
                string Mensaje = "Estimado " + manager.FirstName + "  " + manager.LastName + " <br/><br/> " + "Su contraseña de inicio es: " + pass;
                ToolsHelper.SendMail(CorreoElectronico, "Confirmación de cuenta", Mensaje);
                apiResp = new ApiResponse
                {
                    Message = "Action was executed"
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
        [Route("api/updateAirportManager")]
        public IHttpActionResult Update(AirportManager manager)
        {
            try
            {
                mng.Update(manager);
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

        [Route("api/deleteAirportManager")]
        public IHttpActionResult RemoveAirportManager(AirportManager manager)
        {
            try
            {
                mng.Delete(manager);
                apiResp = new ApiResponse
                {
                    Message = "Action was exectued."
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

        [Route("api/getAdminAirportByAirportId")]
        public IHttpActionResult GetAdminAirportByAirportId(string ID)
        {
            try
            {
                var airportManager = new AirportManager
                {
                    AirportID = ID
                };

                airportManager = mng.RetrieveAdminAirportByAirportId(airportManager);
                apiResp.Data = airportManager;
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



