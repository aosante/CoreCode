using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO.Dashboard
{
    public class GeneralReportAirport : BaseEntity
    {
        public decimal StoresGain  { get; set; }
        public decimal GatesGain { get; set; }
        public decimal RunwayLandingGain { get; set; }
        public List<FullStoreInformation> Stores { get;set; }
        public List<Gate> Gates { get;set; }
        public List<Flight> Flights { get; set; }
        public List<Flight> FlightsPerMonth { get; set; }
        public List<Flight> FlightsThisWeek {get; set; }
        public List<Airline> Airlines {get; set; }
    }
}
