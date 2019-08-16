using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ExceptionDomain
    {
        public string ExcMessage { get; set; }    // сообщение об исключении
        public string ExcStackTrace { get; set; }  // стек исключения
        public string ExcSource { get; set; }    // источник исключения
        public DateTime ExcDate { get; set; }  // дата и время исключения
    }
}
