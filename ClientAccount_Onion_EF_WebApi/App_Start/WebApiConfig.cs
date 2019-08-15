using ClientAccount_Onion_EF_WebApi.Attributes;
using FluentValidation.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ClientAccount_Onion_EF_WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Вызов инициализации Fluent Validation
            FluentValidationModelValidatorProvider.Configure(config);

            //Глобальный фильтр действия - фиксирует в журнале RequestLogEntries все отправляемые на сервер запросы
            config.Filters.Add(new CustomActionFilterAttribute());

            //Глобальный фильтр действия
            config.Filters.Add(new ModelValidationFilterAttribute());

            //Глобальный фильтр исключения - проверяет тип обрабатываемого исключения и при необходимости подменяет ответ
            config.Filters.Add(new CustomExceptionFilterAttribute_1());
            config.Filters.Add(new CustomExceptionFilterAttribute_2());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
