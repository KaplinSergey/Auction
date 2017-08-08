using System;

namespace DAL.Interfaces.DTO
{
    public class DalExceptionInformation:IEntity
    {
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public DateTime Date { get; set; }
    }
}
