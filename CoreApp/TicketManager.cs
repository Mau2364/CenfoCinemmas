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
            if (HasEmptyFields(t))
            {
                throw new Exception("Se deben completar todos los espacios");
            }
            if (t.Price<=0)
            {
                throw new Exception("El precio del ticket debe ser mayor a 0");
            }
            if (t.Movie == null || t.Movie.Id <= 0)
            {
                throw new Exception("Debe seleccionar una pelicula valida ");
            }
            if (t.Date <= DateTime.Now.Date)
            {
                throw new Exception("La fecha del ticket no puede ser anterior a hoy");
            }

            var tCrud = new TicketCrudFactory();
            tCrud.Create(t);
        }

        //validaciones
        private bool HasEmptyFields(Ticket ticket)
        {
            return string.IsNullOrWhiteSpace(ticket.Type);
        }
    }
}