using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using DomainServices.Mapper;
using System.Web.Http;
using System.Net;

namespace DomainServices.Services
{
    public class ClientService : IClient
    {
        private readonly IClientRepository clientRepository;
        public ClientService(IClientRepository _clientRepository)
        {
            this.clientRepository = _clientRepository;
        }
        public IList<ClientDomain> GetAll()
        {
            return clientRepository.GetAllCl()
                .Select(_ => _.ClientFromInfraToDomain())
                .ToList();
        }

        public ClientDomain Get(int id)
        {
            var temp = clientRepository.GetCl(id).ClientFromInfraToDomain();
            return temp;
        }

        public void Create(ClientDomain inst)
        {
            clientRepository.CreateCl(inst.ClientFromDomainToInfra());
        }

        public void Update(ClientDomain inst)
        {
            clientRepository.UpdateCl(inst.ClientFromDomainToInfra());
        }
        public void Delete(int id)
        {
            clientRepository.DeleteCl(id);
        }
    }
}

