using DataAccess.DAO;
using Entities_DTOS;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace DataAccess.CRUD
{
    public class TicketCrudFactory : CrudFactory
    {
        public TicketCrudFactory()
        {
            sqlDao = SqlDao.getInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();

            sqlOperation.ProcedureName = "CRE_TICKET_PR";

            sqlOperation.AddDouble("P_PRICE", ticket.Price);
            sqlOperation.AddTimeParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);
            sqlOperation.AddIntParameter("P_MOVIE_ID", ticket.Movie.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO) => throw new NotImplementedException();
        public override List<T> RetrieveAll<T>() => throw new NotImplementedException();
        public override T RetrieveById<T>(int id) => throw new NotImplementedException();
        public override void Update(BaseDTO baseDTO) => throw new NotImplementedException();
    }
}
