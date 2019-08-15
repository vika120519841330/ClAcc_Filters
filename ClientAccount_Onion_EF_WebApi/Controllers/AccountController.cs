using ClientAccount_Onion_EF_WebApi.Models;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ClientAccount_Onion_EF_WebApi.Mappers;
using ClientAccount_Onion_EF_WebApi.Validators;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;

namespace ClientAccount_Onion_EF_WebApi.Controllers
{
    [RoutePrefix("api/account")]
    [AccountValidation]
    public class AccountController : ApiController
    {
        private readonly IAccount accountService;
        public AccountController(IAccount _accountService)
        {
            this.accountService = _accountService;
        }

        // GET api/<controller>
        [HttpGet, Route("")]
        public HttpResponseMessage GetAll()
        {
            var list = accountService.GetAll()
                .Select(_ => _.AccountFromDomainToView())
                .ToList();
            HttpResponseMessage response = Request.CreateResponse<IList<AccountView>>(HttpStatusCode.OK, list);
            return response;

        }

        // GET api/<controller>/5
        [HttpGet, Route("{id}")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            var temp = accountService.Get(id).AccountFromDomainToView();
            var t = new AccountValidationAttribute();
            if (!(t.IsValid(temp)))
            {
                var resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, t.ErrorMessage.ToString());
                return resp;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse<AccountView>(HttpStatusCode.OK, temp);
                return response;
            }
        }

        // POST api/<controller>
        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody]AccountView inst)
        {
            var t = new AccountValidationAttribute();
            if (!(t.IsValid(inst)))
            {
                var resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, t.ErrorMessage);
                return resp;
            }
            else
            {
                accountService.Create(inst.AccountFromViewToDomain());
                HttpResponseMessage response = Request.CreateResponse<string>(HttpStatusCode.Created, "Account успешно создан!!");
                return response;
            }
        }

        // PUT api/<controller>
        [HttpPut, Route("")]
        public HttpResponseMessage Update([FromBody]AccountView inst)
        {
            var t = new AccountValidationAttribute();
            if (!(t.IsValid(inst)))
            {
                var resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, t.ErrorMessage);
                return resp;
            }
            else
            {
                accountService.Update(inst.AccountFromViewToDomain());
                HttpResponseMessage response = Request.CreateResponse<string>(HttpStatusCode.OK, "Account успешно обновлен!!");
                return response;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            var temp = accountService.Get(id).AccountFromDomainToView();
            var t = new AccountValidationAttribute();
            if (!(t.IsValid(temp)))
            {
                var resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, t.ErrorMessage);
                return resp;
            }
            else
            {
                accountService.Delete(id);
                HttpResponseMessage response = Request.CreateResponse<string>(HttpStatusCode.OK, "Account успешно удален!!");
                return response;
            }

        }
    }
}