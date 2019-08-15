using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClient
    {
        IList<ClientDomain> GetAll(); // получение всех объектов
        ClientDomain Get(int id); // получение одного объекта по id
        void Create(ClientDomain item); // создание объекта
        void Update(ClientDomain item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
