using Domain.Interfaces;
using Domain.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ClientAccount_Onion_EF_WebApi.Attributes
{
    public class CustomExceptionFilterAttribute_1 : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotSupportedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Введенный Вами запрос не поддерживается системой.")
                };
            }
        }
    }
    public class CustomExceptionFilterAttribute_2 : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NullReferenceException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Вы ссылаетесь на несуществующий ресурс.")
                };
            }
        }
    }

    public class ExceptionLoggerAttribute : ExceptionFilterAttribute
    {
        // метод, извлекающий зависимость
        public T GetService<T>(HttpActionExecutedContext excContext)
        {
            return (T)excContext.Request.GetDependencyScope().GetService(typeof(T));
        }

        public override void OnException(HttpActionExecutedContext excContext)
        {
            var exclogService = GetService<IExcLogService>(excContext);

            if (excContext.Exception != null)
            {
                exclogService.LogExc(new ExceptionDomain()
                {
                    ExcMessage = excContext.Exception.Message,
                    ExcStackTrace = excContext.Exception.StackTrace,
                    ExcSource= excContext.Exception.Source,
                    ExcDate = DateTime.Now
                });
            }
        }
    }
}