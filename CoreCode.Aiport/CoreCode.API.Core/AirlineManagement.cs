using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class AirlineManagement
    {

        private readonly AirlineCrudFactory crudAirline;

        public AirlineManagement()
        {
            crudAirline = new AirlineCrudFactory();
        }

        public void Create(Airline airline)
        {
            crudAirline.Create(airline);
        }

        public List<Airline> RetrieveAll()
        {
            return crudAirline.RetrieveAll<Airline>();
        }

        public List<Airline> RetrieveWaitingAirlines()
        {
            return crudAirline.RetrieveWaitingAirlines<Airline>();
        }

        public List<Airline> RetrieveAcceptedAirlines()
        {
            return crudAirline.RetrieveAcceptedAirlines<Airline>();
        }

        public List<Airline> RetrieveDeniedAirlines()
        {
            return crudAirline.RetrieveDeniedAirlines<Airline>();
        }

        public List<Airline> RetrieveAvailableAirlines()
        {
            return crudAirline.RetrieveAvailableAirlines<Airline>();
        }

        public List<Airline> RetrieveUnvailableAirlines()
        {
            return crudAirline.RetrieveUnvailableAirlines<Airline>();
        }

        public List<Airline> RetrieveAssociatedAirlines(Airline airline)
        {
            return crudAirline.RetrieveAssociatedAirlines<Airline>(airline);
        }

        public List<Airline> RetrieveRejectedAirlines(Airline airline){
            return crudAirline.RetrieveRejectedAirlines<Airline>(airline);
        }

        public List<Airline> RetrieveWaitingAirlines(Airline airline)
        {
            return crudAirline.RetrieveWaitingAirlines<Airline>(airline);
        }


        public Airline RetrieveById(Airline airline)
        {
            return crudAirline.Retrieve<Airline>(airline);
        }

        public void Update(Airline airline)
        {
            crudAirline.Update(airline);
        }

        public void Delete(Airline airline)
        {
            crudAirline.Delete(airline);
        }


    }
}
