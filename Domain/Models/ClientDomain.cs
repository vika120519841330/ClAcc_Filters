using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ClientDomain
    {
        // Имя первичного ключа сущности - Идентификатор клиента
        public int? ClientId { get; set; }
        // Полное наименование клиента(название юр.лица/ФИО физ.лица)
        public string ClientTitle { get; set; }
        // Отметка о том клиент является юр.лицом (true) или физюлицом(false)
        public bool ClientMarkJuridical { get; set; }
        //УНП юр.лица/Номер паспорта физ.лица
        public string ClientTaxpayNum { get; set; }
        // Номер телефона клиента
        public string ClientPhone { get; set; }
        // Электроная почта клиента
        public string ClientEMail { get; set; }
        // Навигационное свойство - Коллекция всех р/с, привязанных к клиенту
        public IList<AccountDomain> AccountsOfClient { get; set; }

    }

}
