using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class RequestAirlineAirportManagement
    {
        private readonly RequestAirlineAirportCrud requestAirlineAirportCrud;


        public RequestAirlineAirportManagement()
        {
            requestAirlineAirportCrud = new RequestAirlineAirportCrud();
        }

        public void Create(RequestAirlineAirport rqaa)
        {
            requestAirlineAirportCrud.Create(rqaa);
        }
        
       
        public void Update(RequestAirlineAirport rqaa)
        {
            requestAirlineAirportCrud.Update(rqaa);
        }

        

    }
}
