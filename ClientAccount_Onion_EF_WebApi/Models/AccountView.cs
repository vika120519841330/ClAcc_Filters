using ClientAccount_Onion_EF_WebApi.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClientAccount_Onion_EF_WebApi.Models
{
    [AccountValidation]
    public class AccountView
    {
        public int? AccountId { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public int? ClientClientId { get; set; }
    }
}