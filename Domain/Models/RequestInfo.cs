using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RequestInfo
    {
        public string UserIP { get; set; }
        public string Request { get; set; }
        public string Controller { get; set; }
    }
}
