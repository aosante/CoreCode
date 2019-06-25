using CoreCode.API.Core;
using CoreCodeAPI.ActionFilter;
using CoreCode.Entities.POJO;
using CoreCodeAPI.Models;
using CoreCodeAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;
using CoreCode.Exceptions;

namespace CoreCodeAPI.Controllers
{
    [AllowCors]
    public class LoginController : ApiController
    {
        LoginManager mng = new LoginManager();
        ApiResponse apiResp = new ApiResponse();


        [Route("api/getUsers")]
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

        [Route("api/getUser")]
        public IHttpActionResult GetUser(string userName, string password)
        {
            try
            {
                apiResp.Data = mng.RetrieveByUserNameAndPassword(userName, password);

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

        [Route("api/checkIfUserExists")]
        public IHttpActionResult CheckIfUserExists(string userName)
        {
            try
            {
                apiResp.Data = mng.CheckIfUserExists(userName);
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

        [Route("api/checkIfUserExistsByUserNameOrId")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult CheckIfUserExistsById(string userName, string id)
        {
            try
            {
                apiResp.Data = mng.CheckIfUserExistsByUserOrId(userName, id);
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

        [Route("api/updateUser")]
        public IHttpActionResult UpdateUser(User user)
        {
            try
            {
                mng.Update(user);
                apiResp.Message = "Executed";
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

        [Route("api/recoverPassAirline")]
        public IHttpActionResult UpdatePassAirlineAdmin(User user)
        {
            try
            {
                var mng = new LoginManager();

                mng.RecoverPasswordAdminAirline(user);
                var CorreoElectronico = user.Email;
                var pass = user.Password;
                string Mensaje = "Hola" + user.FirstName + "  " + user.LastName + " Se ha reiniciado su contraseña <br/><br/> " + pass + " es su nueva contraseña para ingresar";
                ToolsHelper.SendMail(CorreoElectronico, "Nueva contraseña de ingreso", Mensaje);

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

        [Route("api/recoverPassAirport")]
        public IHttpActionResult UpdatePassAirportAdmin(User user)
        {
            try
            {
                var mng = new LoginManager();

                mng.RecoverPasswordAdminAirline(user);
                var CorreoElectronico = user.Email;
                var pass = user.Password;
                string Mensaje = "Hola" + user.FirstName + " Se ha reiniciado su contraseña <br/><br/> " + pass + " es su nueva contraseña para ingresar";
                ToolsHelper.SendMail(CorreoElectronico, "Nueva contraseña de ingreso", Mensaje);

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