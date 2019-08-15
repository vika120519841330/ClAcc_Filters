using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ClientAccount_Onion_EF_WebApi.Attributes
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // извлекаем зависимость ILogService
            // var logService = (ILogService)actionContext.Request.GetDependencyScope().GetService(typeof(ILogService)); 
            // покрасивее
            var logService = GetService<ILogService>(actionContext);
            string rawRequest = actionContext.Request.Content.ReadAsStringAsync().Result;

            logService.LogRequest(new RequestInfo()
            {
                UserIP = GetClientIpAddress(actionContext.Request),
                Controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName,
                Request = rawRequest
            });
        }
        private string GetClientIpAddress (HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return IPAddress.Parse(((HttpContextBase)request.Properties["MS_HttpContext"]).Request.UserHostAddress).ToString();
            }
            return String.Empty;
        }
       
        public T GetService<T> (HttpActionContext actionContext)
        {
            return (T)actionContext.Request.GetDependencyScope().GetService(typeof(T));
        }

        //public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        //{
        //    throw new Exception("Test");
        //}
    }
}