using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class FlightManagement
    {

        private readonly FlightCrudFactory crudFlight;

        public FlightManagement()
        {
            crudFlight = new FlightCrudFactory();
        }

        public void Create(Flight flight)
        {
            crudFlight.Create(flight);
        }

        public List<Flight> RetrieveAll()
        {
            return crudFlight.RetrieveAll<Flight>();
        }

        public List<Flight> flightsOnTime( )
        {
            return crudFlight.RetrieveOnTime<Flight>();
        }

        public List<Flight> flightsCanceled( )
        {
            return crudFlight.RetrieveCanceled<Flight>();
        }

        public List<Flight> flightsDelay( )
        {
            return crudFlight.RetrieveDelay<Flight>();
        }

        public Flight RetrieveById(Flight flight)
        {
            return crudFlight.Retrieve<Flight>(flight);
        }

        public void Update(Flight flight)
        {
            crudFlight.Update(flight);
        }

        public void Delete(Flight flight)
        {
            crudFlight.Delete(flight);
        }


    }
}
