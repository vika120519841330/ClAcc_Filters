using ClientAccount_Onion_EF_WebApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAccount_Onion_EF_WebApi.Validation
{
    public class ClientModelValidator : AbstractValidator<ClientView>
    {
        public ClientModelValidator()
        {
            RuleFor(_ => _.ClientId)
                .NotEmpty()
                .WithMessage("Укажите идентификационный номер клиента.")
                .InclusiveBetween(1, 1000000)
                .WithMessage("Значение идентификационного номера клиента вышло за допустимые пределы(от 1 до 1000000).")
                ;

            RuleFor(_ => _.ClientTitle)
                .NotEmpty()
                .WithMessage("Укажите наименование клиента.")
                .MinimumLength(3)
                .WithMessage("Наименование клиента должно содержать не менее 3 символов.")
                .MaximumLength(50)
                .WithMessage("Наименование клиента должно содержать не более 50 символов.")
                ;

            RuleFor(_ => _.ClientMarkJuridical)
                .NotNull()
                .WithMessage("Укажите принадлежность клиента к юридическим/физическим лицам." +
                "Значение должно принимать одно из двух значений - true или false!")
                .Equals(false||true)
                ;

            RuleFor(_ => _.AccountsOfClient.Count)
                .InclusiveBetween(1, 10)
                .WithMessage("Колличество р/с для одного клиента ограниченно пределом - от 1 до 10.")
                ;

            RuleFor(_ => _.ClientPhone)
                .NotEmpty()
                .WithMessage("Контактный номер телефона не установлен")
                .Matches(@"^\+(375)-\d{2}-\d{3}-\d{2}-\d{2}$")
                ;

            RuleFor(_ => _.ClientEMail)
                .NotEmpty()
                .WithMessage("Адрес электронной почты  не установлен")
                .Matches(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$")
                ;

            // Длина поля, если клиент является юр.лицом
            RuleFor(_ => _.ClientTaxpayNum)
                .Length(9)
                .When(_ => _.ClientMarkJuridical == true)
                .WithMessage("УНН должен содержать 9 цифр.")
                ;

            // Длина поля, если клиент является физ.лицом
            RuleFor(_ => _.ClientTaxpayNum)
                .Length(14)
                .When(_ => _.ClientMarkJuridical == false)
                .WithMessage("Номер паспорта (идентификационный номер паспорта) должен содержать 14 цифр.")
                ;
        }
    }
}