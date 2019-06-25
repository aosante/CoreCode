using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class PassengerManagement
    {
        private readonly PassengerCrudFactory crudFaq;

        public PassengerManagement()
        {
            crudFaq = new PassengerCrudFactory();

        }

        public void Create(Passenger passenger)
        {
            
                var c = crudFaq.Retrieve<Passenger>(passenger);

                if (c != null)
                {
                    //FAQ already exist
                    
                } else { crudFaq.Create(passenger); }

                
          
        }

        public List<Passenger> RetrieveAll()
        {
            return crudFaq.RetrieveAll<Passenger>();
        }

        public Passenger RetrieveById(Passenger passenger)
        {
            return crudFaq.Retrieve<Passenger>(passenger);
        }

        public void Update(Passenger passenger)
        {
            crudFaq.Update(passenger);
        }

        public void Delete(Passenger passenger)
        {
            crudFaq.Delete(passenger);
        }
    }
}
