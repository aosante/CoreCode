using CoreCode.API.Core;
using CoreCode.Entities.POJO;
using System;
using System.Web.Http.Filters;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace CoreCodeAPI.ActionFilter
{
    public class AllowCorsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            
            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                base.OnActionExecuted(actionExecutedContext);
            
        }
    }
}