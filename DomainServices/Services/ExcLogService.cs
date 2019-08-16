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
    public class ExcLogService : IExcLogService
    {
        private readonly IExcLogRepository exclogRepository;
        public ExcLogService(IExcLogRepository _exclogRepository)
        {
            exclogRepository = _exclogRepository;
        }
        public void LogExc(ExceptionDomain excInfo)
        {
            exclogRepository.InsertExc(new Infrastructure.Models.ExceptionInfra()
            {
                ExcMessage = excInfo.ExcMessage,
                ExcStackTrace = excInfo.ExcStackTrace,
                ExcSource = excInfo.ExcSource,
                ExcDate = excInfo.ExcDate
            });
        }
    }
}
