using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO.Dashboard
{
    public class GeneralAdminReport : BaseEntity
    {
        public double GeneralFlightGain { get; set; }
        public double GeneralTicketGain { get; set; }
        public double AirportCount { get; set; }
        public double AirlineCount { get; set; }
        public List<Airport> AirportList { get; set; }
        public List<Airline> AirlineList { get; set; }
        public double GeneralGain { get; set; }
    }
}
