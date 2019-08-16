using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using InfrastructureServices.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices.Contexts
{
    public class MyContext : DbContext
    {
        public DbSet<ClientInfrastr> Clients { get; set; }
        public DbSet<AccountInfrastr> Accounts { get; set; }
        public DbSet<RequestLogEntry> RequestLogEntries { get; set; }
        public DbSet<ExceptionInfra> ExceptionLogEntries { get; set; }

        //Конструктор, инициализирующий БД
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
          
        }

        // Инициализация БД начальными значениями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region
            // Инициализация таблицы с моделями Client
            modelBuilder.Entity<ClientInfrastr>().HasData(
                 new ClientInfrastr
                 {
                     ClientId = 1,
                     ClientTitle = "Иванов Иван Иванович",
                     ClientMarkJuridical = false,
                     ClientPhone = "+375-44-458-77-33",
                     ClientEMail = "12google.com",
                     ClientTaxpayNum = "MP1234"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 2,
                     ClientTitle = "Петров Петр Петрович",
                     ClientMarkJuridical = false,
                     ClientPhone = "+44-454-33-44",
                     ClientEMail = "234@google.com",
                     ClientTaxpayNum = "PB1234964"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 3,
                     ClientTitle = "Сидоров Николай Петрович",
                     ClientMarkJuridical = false,
                     ClientPhone = "+375-29-456-99-00",
                     ClientEMail = "12@google.com",
                     ClientTaxpayNum = "PB7812764"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 4,
                     ClientTitle = "Стройтехносистем",
                     ClientMarkJuridical = true,
                     ClientPhone = "+375-33-430-00-33",
                     ClientEMail = "1fgh2@tut.by",
                     ClientTaxpayNum = "123456789"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 5,
                     ClientTitle = "Види",
                     ClientMarkJuridical = true,
                     ClientPhone = "+375-29-579-44-38",
                     ClientEMail = "1fghghz2@tut.by",
                     ClientTaxpayNum = "123456788"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 6,
                     ClientTitle = "Промтехнология",
                     ClientMarkJuridical = true,
                     ClientPhone = "+375-33-456-12-22",
                     ClientEMail = "vbfh@tut.by",
                     ClientTaxpayNum = "123456787"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 7,
                     ClientTitle = "Модная Галактика",
                     ClientMarkJuridical = true,
                     ClientPhone = "+375-33-345-99-36",
                     ClientEMail = "zhzh6@tut.by",
                     ClientTaxpayNum = "123"
                 }
                 );
            #endregion

            #region
            // Инициализация таблицы с моделями Account
            modelBuilder.Entity<AccountInfrastr>().HasData(
                new AccountInfrastr
                {
                    AccountId = 1,
                    AccountBalance = 120,
                    AccountNumber = "1234561111111222",
                    ClientClientId = 1
                },
                new AccountInfrastr
                {
                    AccountId = 2,
                    AccountBalance = -5,
                    AccountNumber = "12345612345678921782",
                    ClientClientId = 1
                },
                new AccountInfrastr
                {
                    AccountId = 3,
                    AccountBalance = 1100,
                    AccountNumber = "12345125874563216783",
                    ClientClientId = 2
                },
                new AccountInfrastr
                {
                    AccountId = 4,
                    AccountBalance = 1230,
                    AccountNumber = "12345672655899235584",
                    ClientClientId = 2
                },
                new AccountInfrastr
                {
                    AccountId = 5,
                    AccountBalance = 57457,
                    AccountNumber = "12345616259222296785",
                    ClientClientId = 3
                },
                 new AccountInfrastr
                 {
                     AccountId = 6,
                     AccountBalance = 1250,
                     AccountNumber = "1234563542866528786",
                     ClientClientId = 4
                 },
                 new AccountInfrastr
                 {
                     AccountId = 7,
                     AccountBalance = 124530,
                     AccountNumber = "1234635426262656787",
                     ClientClientId = 4
                 },
                 new AccountInfrastr
                 {
                     AccountId = 8,
                     AccountBalance = 0,
                     AccountNumber = "1234567654168341688",
                     ClientClientId = 5
                 },
                 new AccountInfrastr
                 {
                     AccountId = 9,
                     AccountBalance = 6550,
                     AccountNumber = "1234511125888456789",
                     ClientClientId = 6
                 },
                 new AccountInfrastr
                 {
                     AccountId = 10,
                     AccountBalance = 124530,
                     AccountNumber = "1234555698512226790",
                     ClientClientId = 6
                 },
                new AccountInfrastr
                {
                    AccountId = 11,
                    AccountBalance = 0,
                    AccountNumber = "12345656698888422791",
                    ClientClientId = 6
                },
                new AccountInfrastr
                {
                    AccountId = 12,
                    AccountBalance = 15990,
                    AccountNumber = "12345625555669523792",
                    ClientClientId = 7
                }
                );
            #endregion

            modelBuilder.ApplyConfiguration<ClientInfrastr>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<AccountInfrastr>(new AccountConfiguration());
            modelBuilder.ApplyConfiguration<RequestLogEntry>(new LogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

