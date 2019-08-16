using Infrastructure.Interfaces;
using Infrastructure.Models;
using InfrastructureServices.Contexts;

namespace InfrastructureServices.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly MyContext context;
        public LogRepository(MyContext _context)
        {
            this.context = _context;
        }
        // Журнал для фиксации всех поступающих запросов
        public void Insert (RequestLogEntry entry)
        {
            context.RequestLogEntries.Add(entry);
            context.SaveChanges();
        }
    }
}
