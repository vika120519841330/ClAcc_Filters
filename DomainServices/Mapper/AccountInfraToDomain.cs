using Domain.Models;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Mapper
{
    public static class AccountInfraToDomain
    {
        public static AccountDomain AccountFromInfraToDomain(this AccountInfrastr @this)
        {
            if (@this != null)
            {
                return new AccountDomain()
                {
                    AccountId = @this.AccountId,
                    AccountNumber = @this.AccountNumber,
                    AccountBalance = @this.AccountBalance,
                    ClientClientId = @this.ClientClientId
                    //,ClientOfAccount = @this.ClientOfAccount.ClientFromInfraToDomain()

                };
            }
            else
            {
                return null;
            }
        }
        public static AccountInfrastr AccountFromDomainToInfra(this AccountDomain @this)
        {
            if (@this != null)
            {
                return new AccountInfrastr()
                {
                    AccountId = @this.AccountId,
                    AccountNumber = @this.AccountNumber,
                    AccountBalance = @this.AccountBalance,
                    ClientClientId = @this.ClientClientId
                    //,ClientOfAccount = @this.ClientOfAccount.ClientFromDomainToInfra()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
