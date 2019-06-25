using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class AirportManagement
    {

        private readonly AirportCrudFactory crudAirport;

        public AirportManagement()
        {
            crudAirport = new AirportCrudFactory();
        }

        public void Create(Airport airport)
        {
            crudAirport.Create(airport);
        }

        public List<Airport> RetrieveAll()
        {
            return crudAirport.RetrieveAll<Airport>();
        }
        public List<Airport> RetrieveAvailable()
        {
            return crudAirport.RetrieveAvailable<Airport>();
        }
        public List<Airport> RetrieveUnavailable()
        {
            return crudAirport.RetrieveUnavailable<Airport>();
        }

        public List<Store> RetrieveStores(Airport airport)
        {
            return crudAirport.RetrieveStores<Store>(airport.ID);
        }

        public List<Gate> RetrieveGates(Airport airport)
        {
            return crudAirport.RetrieveGates<Gate>(airport.ID);
        }
        public List<Gate> RetrieveAvailableGates(Airport airport)
        {
            return crudAirport.RetrieveAvailableGates<Gate>(airport.ID);
        }

        public List<Gate> RetrieveUnavailableGates(Airport airport)
        {
            return crudAirport.RetrieveUnavailableGates<Gate>(airport.ID);
        }


        public Airport RetrieveById(Airport airport)
        {
            return crudAirport.Retrieve<Airport>(airport);
        }

        public void Update(Airport airport)
        {
            crudAirport.Update(airport);
        }

        public void Delete(Airport airport)
        {
            crudAirport.Delete(airport);
        }


        public List<Airport> RetrieveAssociatedAirports(Airport airport)
        {
            return crudAirport.RetrieveAssociatedAirports<Airport>(airport);
        }
        public List<Airport> RetrieveNonAssociatedAirports(Airport airport)
        {
            return crudAirport.RetrieveNonAssociatedAirports<Airport>(airport);
        }
        public List<Airport> RetrievePossibleDestinyAirports(RequestAirlineAirport rqaa)
        {
            return crudAirport.RetrievePossibleDestinyAirports<Airport>(rqaa);
        }

    }
}
