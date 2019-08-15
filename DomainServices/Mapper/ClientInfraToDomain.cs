using Domain.Models;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Mapper
{
    public static class ClientInfraToDomain
    {
        public static ClientDomain ClientFromInfraToDomain(this ClientInfrastr @this)
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
                    AccountsOfClient = @this.AccountsOfClient.Select(_ => _.AccountFromInfraToDomain()).ToList()
                };
            }
            else
            {
                return null;
            }
        }
        public static ClientInfrastr ClientFromDomainToInfra(this ClientDomain @this)
        {
            if (@this != null)
            {
                return new ClientInfrastr()
                {
                    ClientId = @this.ClientId,
                    ClientTitle = @this.ClientTitle,
                    ClientMarkJuridical = @this.ClientMarkJuridical,
                    ClientTaxpayNum = @this.ClientTaxpayNum,
                    ClientPhone = @this.ClientPhone,
                    ClientEMail = @this.ClientEMail,
                    AccountsOfClient = @this.AccountsOfClient.Select(_ => _.AccountFromDomainToInfra()).ToList()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
