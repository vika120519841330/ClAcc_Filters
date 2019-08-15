using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class AccountInfrastr
    {
        public int? AccountId { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public int? ClientClientId { get; set; }
        // владелец р/с
        //public ClientInfrastr ClientOfAccount { get; set; }
    }
}
