using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class ExceptionInformation
    {
        [Key]
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
    }
}
