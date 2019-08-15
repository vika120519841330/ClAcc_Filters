using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository logRepository;
        public LogService(ILogRepository _logRepository)
        {
            logRepository = _logRepository;
        }
        public void LogRequest (RequestInfo requestInfo)
        {
            logRepository.Insert(new Infrastructure.Models.RequestLogEntry()
            {
                UserIP = requestInfo.UserIP,
                Controller = requestInfo.Controller,
                Request = requestInfo.Request

            });
        }
    }
}
