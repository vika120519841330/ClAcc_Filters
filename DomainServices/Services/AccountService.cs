using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using DomainServices.Mapper;
using System.Web.Http;
using System.Net;

namespace DomainServices.Services
{
    public class AccountService : IAccount
    {
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository _accountRepository)
        {
            this.accountRepository = _accountRepository;
        }
        public IList<AccountDomain> GetAll()
        {
            return accountRepository.GetAllAcc()
                .Select(_ => _.AccountFromInfraToDomain())
                .ToList();
        }

        public AccountDomain Get(int id)
        {
            var temp = accountRepository.GetAcc(id).AccountFromInfraToDomain();
            return temp;
        }

        public void Create(AccountDomain inst)
        {
            accountRepository.CreateAcc(inst.AccountFromDomainToInfra());
        }

        public void Update(AccountDomain inst)
        {
            accountRepository.UpdateAcc(inst.AccountFromDomainToInfra());
        }
        public void Delete(int id)
        {
            accountRepository.DeleteAcc(id);
        }
    }
}