using Infrastructure.Interfaces;
using Infrastructure.Models;
using InfrastructureServices.Contexts;

namespace InfrastructureServices.Repositories
{
    public class ExcLogRepository : IExcLogRepository
    {
        private readonly MyContext context;
        public ExcLogRepository(MyContext _context)
        {
            this.context = _context;
        }
        // Метод для фиксации всех возникающих исключений
        public void InsertExc(ExceptionInfra excEntry)
        {
            context.ExceptionLogEntries.Add(excEntry);
            context.SaveChanges();
        }
    }
}
