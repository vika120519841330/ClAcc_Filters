using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        IList<ClientInfrastr> GetAllCl(); // получение всех объектов
        ClientInfrastr GetCl(int id); // получение одного объекта по id
        void CreateCl(ClientInfrastr item); // создание объекта
        void UpdateCl(ClientInfrastr item); // обновление объекта
        void DeleteCl(int id); // удаление объекта по id
    }
}
