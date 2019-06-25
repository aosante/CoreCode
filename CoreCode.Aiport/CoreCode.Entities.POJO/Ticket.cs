using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Ticket : BaseEntity
    {
        public String Id {get; set; }
        public String Id_Flight {get; set; }
        public String Ticket_Class {get; set; }
        public String Status { get; set; }
        public Decimal Price { get; set; }
        public DateTime Buy_Date { get; set; }
        public String Id_Person { get; set; }
        public String Person_Name { get; set; }
    }
}
