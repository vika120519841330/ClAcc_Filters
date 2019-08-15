using System;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Infrastructure.Interfaces;
using InfrastructureServices.Contexts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http;

namespace InfrastructureServices.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyContext context;
        public AccountRepository(MyContext _context)
        {
            this.context = _context;
        }
        public IList<AccountInfrastr> GetAllAcc()
        {
            return context.Accounts
                .ToList()
                ;
        }

        public AccountInfrastr GetAcc(int id)
        {
            var temp = context.Accounts.Find(id);
            return temp;
        }

        public void CreateAcc(AccountInfrastr inst)
        {
            context.Accounts.Add(inst);
            context.SaveChanges();
        }

        public void UpdateAcc(AccountInfrastr inst)
        {
            //var temp = context.Accounts.Find(inst.AccountId);
            context.Entry(inst).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteAcc(int id)
        {
            var tmp = context.Accounts.Find(id);
            context.Accounts.Remove(tmp);
            context.SaveChanges();
        }
    }
}