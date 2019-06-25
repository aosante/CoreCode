using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Flight : BaseEntity
    {
        public String Id {get; set; }
        public String Airline_Id {get; set; }
        public String Origin_Airport_Id {get; set; }
        public String Destiny_Airport_Id { get; set; }
        public DateTime Departure_Time {get; set; }
        public DateTime Arrival_DateTime { get; set; }
        public String Status {get; set;}

        public String Id_Airplane => "1";

        public String Id_Gate { get; set; }
    }
}
