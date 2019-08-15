using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IAccount
    {
        IList<AccountDomain> GetAll(); // получение всех объектов
        AccountDomain Get(int id); // получение одного объекта по id
        void Create(AccountDomain item); // создание объекта
        void Update(AccountDomain item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
