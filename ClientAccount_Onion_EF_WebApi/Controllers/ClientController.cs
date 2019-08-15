using ClientAccount_Onion_EF_WebApi.Models;
using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ClientAccount_Onion_EF_WebApi.Mappers;
using System.Net.Http;
using FluentValidation.Attributes;
using ClientAccount_Onion_EF_WebApi.Validation;

namespace ClientAccount_Onion_EF_WebApi.Controllers
{
    [RoutePrefix("api/client")]
    [Validator(typeof(ClientModelValidator))]
    public class ClientController : ApiController
    {
        private readonly IClient clientService;
        public ClientController(IClient _clientService)
        {
            this.clientService = _clientService;
        }

        // GET api/<controller>
        [HttpGet, Route("")]
        public HttpResponseMessage GetAll()
        {
            var list = clientService.GetAll()
                .Select(_ => _.ClientFromDomainToView())
                .ToList();
            HttpResponseMessage response = Request.CreateResponse<IList<ClientView>>(HttpStatusCode.OK, list);
            return response;
        }

        // GET api/<controller>/5
        [HttpGet, Route("{id:int}")]
        public HttpResponseMessage Get([FromUri]int id)
        {
            ClientView temp = clientService.Get(id).ClientFromDomainToView();
            if (temp == null)
            {
                ModelState.AddModelError("GetClientById", "Клиент с запрашиваемым  идентификатором не существует!!!");
                HttpResponseMessage resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);
                return resp;
            }
            HttpResponseMessage response = Request.CreateResponse<ClientView>(HttpStatusCode.OK, temp);
            return response;
        }

        // POST api/<controller>
        [HttpPost, Route("")]
        public HttpResponseMessage Create([FromBody]ClientView inst)
        {
            if (inst == null)
            {
                ModelState.AddModelError("CreateClient", "Не указаны данные для создания клиента!!!");
                HttpResponseMessage resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return resp;
            }
            if (ModelState.IsValid)
            {
                clientService.Create(inst.ClientFromViewToDomain());
                HttpResponseMessage response = Request.CreateResponse<string>(HttpStatusCode.Created, "Client is created!!");
                return response;
            }
            else
            {
                HttpResponseMessage resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return resp;
            }
        }

        // PUT api/<controller>
        [HttpPut, Route("")]
        public HttpResponseMessage Update([FromBody]ClientView inst)
        {
            if (inst == null)
            {
                ModelState.AddModelError("UpdateClient", "Не указаны данные для обновления клиента!!!");
                HttpResponseMessage resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return resp;
            }
            if (ModelState.IsValid)
            {
                clientService.Update(inst.ClientFromViewToDomain());
                HttpResponseMessage response = Request.CreateResponse<string>(HttpStatusCode.OK, "Client is updated!!");
                return response;
            }
            else
            {
                HttpResponseMessage resp = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return resp;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete, Route("{id:int}")]
        public HttpResponseMessage Delete([FromUri]int id)
        {
            ClientView temp = clientService.Get(id).ClientFromDomainToView();
            if (temp == null)
            {
                ModelState.AddModelError("DeleteClient", "Не найден клиент для удаления с указанным идентификатором!!!");
                HttpResponseMessage resp = Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);
                return resp;
            }
            clientService.Delete(id);
            HttpResponseMessage response = Request.CreateResponse<string>(HttpStatusCode.OK, "Client is deleted!!");
            return response;
        }
    }
}