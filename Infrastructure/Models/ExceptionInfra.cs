using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ExceptionInfra
    {
        [Key]
        public int? ExcId { get; set; }
        public string ExcMessage { get; set; }    // сообщение об исключении
        public string ExcStackTrace { get; set; }  // стек исключения
        public string ExcSource { get; set; }    // источник исключения
        public DateTime ExcDate { get; set; }  // дата и время исключения
    }
}
