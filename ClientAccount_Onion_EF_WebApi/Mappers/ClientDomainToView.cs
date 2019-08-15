using System;
using Domain.Models;
using ClientAccount_Onion_EF_WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAccount_Onion_EF_WebApi.Mappers
{
    public static class ClientDomainToView
    {
        public static ClientView ClientFromDomainToView(this ClientDomain @this)
        {
            if (@this != null)
            {
                return new ClientView()
                {
                    ClientId = @this.ClientId,
                    ClientTitle = @this.ClientTitle,
                    ClientMarkJuridical = @this.ClientMarkJuridical,
                    ClientTaxpayNum = @this.ClientTaxpayNum,
                    ClientPhone = @this.ClientPhone,
                    ClientEMail = @this.ClientEMail,
                    AccountsOfClient = @this.AccountsOfClient.Select(_ => _.AccountFromDomainToView()).ToList()
                };
            }
            else
            {
                return null;
            }
        }
        public static ClientDomain  ClientFromViewToDomain(this ClientView @this)
        {
            if (@this != null)
            {
                return new ClientDomain()
                {
                    ClientId = @this.ClientId,
                    ClientTitle = @this.ClientTitle,
                    ClientMarkJuridical = @this.ClientMarkJuridical,
                    ClientTaxpayNum = @this.ClientTaxpayNum,
                    ClientPhone = @this.ClientPhone,
                    ClientEMail = @this.ClientEMail,
                    AccountsOfClient = @this.AccountsOfClient.Select(_ => _.AccountFromViewToDomain()).ToList()
                };
            }
            else
            {
                return null;
            }
        }
    }
}