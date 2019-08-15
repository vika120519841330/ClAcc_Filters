using ClientAccount_Onion_EF_WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAccount_Onion_EF_WebApi.Validators
{
    public class AccountValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var acc = value as AccountView;
            if (acc != null)
            {
                if ((acc.AccountId <= 0) || (acc.AccountId > 10000000))
                {
                    this.ErrorMessage = "Идентификационный номер р/с должен находится в пределах от 1 до 10 000 000!!!";
                    return false;
                }
                if ((acc.ClientClientId <= 0) || (acc.ClientClientId > 1000000))
                {
                    this.ErrorMessage = "Идентификационный номер клиента-владельца расчетного счета должен находится в пределах от 1 до 10 000 000!!!";
                    return false;
                }
                if ((acc.AccountNumber.Length < 20) || (acc.AccountNumber.Length > 20))
                {
                    this.ErrorMessage = "Длина р/с должна составлять 20 символов!!!";
                    return false;
                }
                if ((acc.AccountBalance < 0))
                {
                    this.ErrorMessage = "Баланс расчетного счета должен иметь положительное значение!!!";
                    return false;
                }
                return true;
            }
            else 
            {
                this.ErrorMessage = "Account с запрашиваемым идентификационным номером не существует!!!";
                return false;
            }
        }
    }
}