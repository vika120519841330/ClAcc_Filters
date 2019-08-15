using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class RequestLogEntry
    {
        public int UserId { get; set; }
        public string UserIP { get; set; }
        public string Request { get; set; }
        public string Controller { get; set; }
    }
}
