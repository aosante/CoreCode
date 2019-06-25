using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CoreCode.API.Core;
using CoreCode.API.Core.Managers;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using CoreCodeAPI.Models;

namespace CoreCodeAPI.Controllers
{
    public class UserHistoryController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        [Route("api/userHistory")]
        public IHttpActionResult Get(string userId)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UserHistoryManager();
                apiResp.Data = mng.RetrieveUserHistory(userId);
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

        [Route("api/userHistory/post")]
        public IHttpActionResult Post(UserHistory userHistory)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UserHistoryManager();
                mng.Create(userHistory);
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

        [Route("api/userHistory/put")]
        public IHttpActionResult Put(UserHistory userHistory)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UserHistoryManager();
                mng.Update(userHistory);

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

        [Route("api/userHistory/delete")]
        public IHttpActionResult Delete(UserHistory userHistory)
        {
            try
            {
                apiResp = new ApiResponse();
                var mng = new UserHistoryManager();
                mng.Delete(userHistory);
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