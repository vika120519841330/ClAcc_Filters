using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAccountRepository
    {
        IList<AccountInfrastr> GetAllAcc(); // получение всех объектов
        AccountInfrastr GetAcc(int id); // получение одного объекта по id
        void CreateAcc(AccountInfrastr item); // создание объекта
        void UpdateAcc(AccountInfrastr item); // обновление объекта
        void DeleteAcc(int id); // удаление объекта по id
    }
}
