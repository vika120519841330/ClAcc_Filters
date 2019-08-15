using Infrastructure.Interfaces;
using InfrastructureServices.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices.Services
{
    public class MyContextInitializationService : IMyContextInitializationService
    {
        private readonly MyContext _context;
        private readonly IClientProvider _clProvider;
        private readonly IAccountProvider _acProvider;

        public MyContextInitializationService(MyContext context, IClientProvider clProvider, IAccountProvider acProvider)
        {
            _context = context;
            _clProvider = clProvider;
            _acProvider = acProvider;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            using (var transaction = _context.Database.BeginTransaction())
            {
                // Инициализация таблицы  Clients
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Clients] ON");
                _context.Clients.RemoveRange(_context.Clients);
                _context.Clients.AddRange(_clProvider.GetClients());
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Clients] OFF");

                // Инициализация таблицы  Accounts

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Accounts] ON");
                _context.Accounts.RemoveRange(_context.Accounts);
                _context.Accounts.AddRange(_acProvider.GetAccounts());
                _context.SaveChanges();
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Accounts] OFF");

                transaction.Commit();
            }
        }
    }
}
