using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class TicketManagement
    {

        private readonly TicketCrudFactory crudTicket;

        public TicketManagement()
        {
            crudTicket = new TicketCrudFactory();
        }

        public void Create(Ticket ticket)
        {
            crudTicket.Create(ticket);
        }

        public List<Ticket> RetrieveAll()
        {
            return crudTicket.RetrieveAll<Ticket>();
        }

        //public Ticket RetrieveById(Ticket ticket)
        //{
        //    return crudTicket.Retrieve<Ticket>(ticket);
       // }


        public Ticket RetrieveById(Ticket ticket)        {            Ticket c = null;            try            {                c = crudTicket.Retrieve<Ticket>(ticket);                if (c == null)                {                    throw new BussinessException(4);                }            }            catch (Exception ex)            {                ExceptionManager.GetInstance().Process(ex);            }            return c;        }

        public void Update(Ticket ticket)
        {
            crudTicket.Update(ticket);
        }

        public void Delete(Ticket ticket)
        {
            crudTicket.Delete(ticket);
        }


        public List<Ticket> TicketsOnTime()
        {
            return crudTicket.RetrieveOnTime<Ticket>();
        }

        public List<Ticket> TicketsCanceled()
        {
            return crudTicket.RetrieveCanceled<Ticket>();
        }

        public List<Ticket> TicketsDelay()
        {
            return crudTicket.RetrieveDelay<Ticket>();
        }


    }
}
