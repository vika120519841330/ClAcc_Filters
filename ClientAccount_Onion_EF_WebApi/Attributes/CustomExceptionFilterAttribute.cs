using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
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
}