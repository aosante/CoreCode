using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO.Dashboard
{
    public class AirlineReport : BaseEntity
    {
        public double AmmountOfFlights { get; set; }
        public double AmmountOfSoldTickets { get; set; }
        public double FlightGain { get; set; }
        public List<Airport> AssociatedAirport { get; set; }
        public List<Airport> BestFlightAirports { get; set; }
        public List<Airport> BestTicketAirports { get; set; }
    }
}
