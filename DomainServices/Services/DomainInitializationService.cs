using Domain.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Services
{
    public class DomainInitializationService : IDomainInitializationService
    {
        private readonly IMyContextInitializationService _myContextInitializationService;

        public DomainInitializationService(IMyContextInitializationService myContextInitializationService)
        {
            _myContextInitializationService = myContextInitializationService;
        }

        public void Initialize()
        {
            _myContextInitializationService.Initialize();
        }
    }
}
