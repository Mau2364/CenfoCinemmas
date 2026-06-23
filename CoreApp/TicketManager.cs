using DataAccess.CRUD;
using Entities_DTOS;
using System.Collections.Generic;

namespace CoreApp
{
    public class TicketManager
    {
        public List<Ticket> RetrieveAllTickets()
        {
            var tCrud = new TicketCrudFactory();
            return tCrud.RetrieveAll<Ticket>();
        }

        public void Create(Ticket t)
        {
            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }
    }
}