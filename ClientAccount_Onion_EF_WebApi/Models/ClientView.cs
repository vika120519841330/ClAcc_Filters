using ClientAccount_Onion_EF_WebApi.Validation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientAccount_Onion_EF_WebApi.Models
{
    [Validator(typeof(ClientModelValidator))]
    public class ClientView
    {
        [Key]
        [Required(ErrorMessage = "Идентификатор клиента не установлен")]
        [Range(1, 1000000, ErrorMessage = "Значение идентификационного номера клиента вышло за допустимые пределы")]
        [Display(Name = "Идентификационный номер:")]
        public int? ClientId;

        [Required(ErrorMessage = "Наименование клиента не установлено")]
        [MinLength(3, ErrorMessage = "Наименование клиента должно содержать не менее 3 символов")]
        [MaxLength (50, ErrorMessage = "Наименование клиента должно содержать не более 50 символов")]
        [Display(Name = "Клиент:")]
        public string ClientTitle { get; set; }

        [Required(ErrorMessage = "Статус клиента не установлен")]
        [Display(Name = "Клиент является юридическим лицом:")]
        public bool ClientMarkJuridical { get; set; }

        //Условная валидация для этого поля прописана в отдельном классе - ClientModelValidator 
        public string ClientTaxpayNum { get; set; }

        [Required(ErrorMessage = "Контактный номер телефона не установлен", AllowEmptyStrings = true)]
        [RegularExpression(@"^\+(375)-\d{2}-\d{3}-\d{2}-\d{2}$", ErrorMessage = "Номер телефона должен иметь формат (+375)-хx-xxx-xx-xx")]
        public string ClientPhone { get; set; }


        [Required(ErrorMessage = "Адрес электронной почты не установлен")]
        [EmailAddress (ErrorMessage = "Введенное значение не соответсвует адресу электронной почты")]
        public string ClientEMail { get; set; }

        [Required(ErrorMessage = "У клиента д.б. не менее одного расчетного счета")]
        [Display(Name = "Расчетные счета:")]
        public IList<AccountView> AccountsOfClient { get; set; }
    }
}