using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure.Interfaces;
using System.Web.Http;
using System.Net;

namespace InfrastructureServices.Repositories
{
    public class FakeRepository : IAccountRepository, IClientRepository, IAccountProvider, IClientProvider
    {
        public AccountInfrastr a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12;
        public static List<AccountInfrastr> DBAccounts = new List<AccountInfrastr>();

        public ClientInfrastr c1, c2, c3, c4, c5, c6, c7;
        public static List<ClientInfrastr> DBClients = new List<ClientInfrastr>();

        public FakeRepository()
        {
            // Инициализация р/с
            #region
            a1 = new AccountInfrastr
            {
                AccountId = 1,
                AccountBalance = 120,
                AccountNumber = "12345678112345678111",
                ClientClientId = 1
                //, ClientOfAccount = c1
            };
            DBAccounts.Add(a1);
            a2 = new AccountInfrastr
            {
                AccountId = 2,
                AccountBalance = 0,
                AccountNumber = "12345678688888888882",
                ClientClientId = 1
                //,ClientOfAccount = c1
            };
            DBAccounts.Add(a2);
            a3 = new AccountInfrastr
            {
                AccountId = 3,
                AccountBalance = 1100,
                AccountNumber = "12345788888887776783",
                ClientClientId = 2
                //, ClientOfAccount = c2
            };
            DBAccounts.Add(a3);
            a4 = new AccountInfrastr
            {
                AccountId = 4,
                AccountBalance = 1230,
                AccountNumber = "12345678998766544444",
                ClientClientId = 2
                //, ClientOfAccount = c2
            };
            DBAccounts.Add(a4);
            a5 = new AccountInfrastr
            {
                AccountId = 5,
                AccountBalance = 57457,
                AccountNumber = "12345655988887899785",
                ClientClientId = 3
                //, ClientOfAccount = c3
            };
            DBAccounts.Add(a5);
            a6 = new AccountInfrastr
            {
                AccountId = 6,
                AccountBalance = 1250,
                AccountNumber = "12345678612258888776",
                ClientClientId = 4
                //,ClientOfAccount = c4
            };
            DBAccounts.Add(a6);
            a7 = new AccountInfrastr
            {
                AccountId = 7,
                AccountBalance = 124530,
                AccountNumber = "12345678255885222297",
                ClientClientId = 4
                //,ClientOfAccount = c4
            };
            DBAccounts.Add(a7);
            a8 = new AccountInfrastr
            {
                AccountId = 8,
                AccountBalance = 0,
                AccountNumber = "12345674444555555588",
                ClientClientId = 5
                //, ClientOfAccount = c5
            };
            DBAccounts.Add(a8);
            a9 = new AccountInfrastr
            {
                AccountId = 9,
                AccountBalance = 6550,
                AccountNumber = "12345687710585568789",
                ClientClientId = 6
                //, ClientOfAccount = c6
            };
            DBAccounts.Add(a9);
            a10 = new AccountInfrastr
            {
                AccountId = 10,
                AccountBalance = 124530,
                AccountNumber = "12345679967969699610",
                ClientClientId = 6
                //,ClientOfAccount = c6
            };
            DBAccounts.Add(a10);
            a11 = new AccountInfrastr
            {
                AccountId = 11,
                AccountBalance = 0,
                AccountNumber = "12345679345325246511",
                ClientClientId = 6
                //, ClientOfAccount = c6
            };
            DBAccounts.Add(a11);
            a12 = new AccountInfrastr
            {
                AccountId = 12,
                AccountBalance = 15990,
                AccountNumber = "12345679254641343612",
                ClientClientId = 7
                //, ClientOfAccount = c7
            };
            DBAccounts.Add(a12);
            #endregion
            // Инициализация клиентов
            #region
            c1 = new ClientInfrastr
            {
                ClientId = 1,
                ClientTitle = "Иванов Иван Иванович",
                ClientMarkJuridical = false,
                ClientTaxpayNum = "MP123",
                ClientPhone = "+375-44-458-77-33",
                ClientEMail = "12@google.com",
                AccountsOfClient = new List<AccountInfrastr>() { a1, a2 }
            };
            DBClients.Add(c1);
            c2 = new ClientInfrastr
            {
                ClientId = 2,
                ClientTitle = "Петров Петр Петрович",
                ClientMarkJuridical = false,
                ClientTaxpayNum = "PB1234964",
                ClientPhone = "+375-44-454-33-44",
                ClientEMail = "234@google.com",
                AccountsOfClient = new List<AccountInfrastr>() { a3, a4 }
            };
            DBClients.Add(c2);
            c3 = new ClientInfrastr
            {
                ClientId = 3,
                ClientTitle = "Сидоров Николай Петрович",
                ClientMarkJuridical = false,
                ClientTaxpayNum = "PB7812764",
                ClientPhone = "+375-29-456-99-00",
                ClientEMail = "12@google.com",
                AccountsOfClient = new List<AccountInfrastr>() { a5 }
            };
            DBClients.Add(c3);

            c4 = new ClientInfrastr
            {
                ClientId = 4,
                ClientTitle = "Стройтехносистем",
                ClientMarkJuridical = true,
                ClientTaxpayNum = "123456789",
                ClientPhone = "+375-33-430-00-33",
                ClientEMail = "1fgh2@tut.by",
                AccountsOfClient = new List<AccountInfrastr>() { a6, a7 }
            };
            DBClients.Add(c4);
            c5 = new ClientInfrastr
            {
                ClientId = 5,
                ClientTitle = "Види",
                ClientMarkJuridical = true,
                ClientTaxpayNum = "123456788",
                ClientPhone = "+375-29-579-44-38",
                ClientEMail = "1fghghz2@tut.by",
                AccountsOfClient = new List<AccountInfrastr>() { a8 }
            };
            DBClients.Add(c5);

            c6 = new ClientInfrastr
            {
                ClientId = 6,
                ClientTitle = "Промтехнология",
                ClientMarkJuridical = true,
                ClientTaxpayNum = "123456787",
                ClientPhone = "+375-33-456-12-22",
                ClientEMail = "vbfh@tut.by",
                AccountsOfClient = new List<AccountInfrastr>() { a9, a10, a11 }
            };
            DBClients.Add(c6);
            c7 = new ClientInfrastr
            {
                ClientId = 7,
                ClientTitle = "Модная Галактика",
                ClientMarkJuridical = true,
                ClientTaxpayNum = "123",
                ClientPhone = "+375-33-345-99-36",
                ClientEMail = "zhzh6@tut.by",
                AccountsOfClient = new List<AccountInfrastr>() { a12 }
            };
            DBClients.Add(c7);
            #endregion
        }

        public IList<ClientInfrastr> GetAllCl()
        {
            return DBClients;
        }

        public IList<AccountInfrastr> GetAllAcc()
        {
            return DBAccounts;
        }
        public ClientInfrastr GetCl(int id)
        {
            var temp = DBClients.FirstOrDefault(_ => _.ClientId == id);
            return temp;
        }
        public AccountInfrastr GetAcc(int id)
        {
            var temp = DBAccounts.FirstOrDefault(_ => _.AccountId == id);
            return temp;
        }

        public void CreateCl(ClientInfrastr inst)
        {
            DBClients.Add(inst);
        }

        public void CreateAcc(AccountInfrastr inst)
        {
            DBAccounts.Add(inst);
        }

        public void UpdateAcc(AccountInfrastr inst)
        {
            var temp = DBAccounts.FirstOrDefault(_ => _.AccountId == inst.AccountId);
            temp = inst;
        }

        public void UpdateCl(ClientInfrastr inst)
        {
            var temp = DBClients.FirstOrDefault(_ => _.ClientId == inst.ClientId);
            temp = inst;
           
        }

        public void DeleteAcc(int id)
        {
            var temp = DBAccounts.FirstOrDefault(_ => _.AccountId == id);
            DBAccounts.Remove(temp);
        }
        public void DeleteCl(int id)
        {
            var temp = DBClients.FirstOrDefault(_ => _.ClientId == id);
             DBClients.Remove(temp);
        }
        public IList<ClientInfrastr> GetClients()
        {
            return DBClients.ToList();
        }
        public IList<AccountInfrastr> GetAccounts()
        {
            return DBAccounts.ToList();
        }
    }
}

  