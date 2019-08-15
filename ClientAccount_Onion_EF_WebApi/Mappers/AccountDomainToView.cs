using Domain.Models;
using ClientAccount_Onion_EF_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAccount_Onion_EF_WebApi.Mappers
{
    public static class AccountDomainToView
    {

        public static AccountView AccountFromDomainToView(this AccountDomain @this)
        {
            if (@this != null)
            {
                return new AccountView()
                {
                    AccountId = @this.AccountId,
                    AccountNumber = @this.AccountNumber,
                    AccountBalance = @this.AccountBalance,
                    ClientClientId = @this.ClientClientId
                    //,ClientOfAccount = @this.ClientOfAccount.ClientFromDomainToView()
                };
            }
            else
            {
                return null;
            }
        }
        public static AccountDomain AccountFromViewToDomain(this AccountView @this)
        {
            if (@this != null)
            {
                return new AccountDomain()
                {
                    AccountId = @this.AccountId,
                    AccountNumber = @this.AccountNumber,
                    AccountBalance = @this.AccountBalance,
                    ClientClientId = @this.ClientClientId
                    //,ClientOfAccount = @this.ClientOfAccount.ClientFromViewToDomain()
                };
            }
            
            else
            {
                return null;
            }
        }
    }
}