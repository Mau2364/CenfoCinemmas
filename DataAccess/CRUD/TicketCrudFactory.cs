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

        public override List<T> RetrieveAll<T>()
        {
            var lstTickets = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_TICKET_PR";

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                foreach (var result in lstResults)
                {
                    var ticket = BuildTicket(result);

                    lstTickets.Add((T)Convert.ChangeType(ticket, typeof(T)));
                }
            }

            return lstTickets;
        }

        private Ticket BuildTicket(Dictionary<string, object> row)
        {
            return new Ticket()
            {
                Id = (int)row["Id"],
                Price = Convert.ToDouble(row["Price"]),
                Schedule = (TimeSpan)row["Schedule"],
                Date = (DateTime)row["DateTicket"],
                Type = (string)row["Type"],

                Movie = new Movie()
                {
                    Id = (int)row["MovieId"],
                    Title = (string)row["Title"],
                    Synopsis = (string)row["Synopsis"],
                    Gender = (string)row["Gender"],
                    Clasificacion = (string)row["Clasificacion"],
                    Image = (string)row["Image"],
                    Status = (string)row["Status"]
                }
            };
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_TICKET_PR";

            sqlOperation.AddIntParameter("P_ID", ticket.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }
        public override T RetrieveById<T>(int id) => throw new NotImplementedException();

        public override void Update(BaseDTO baseDTO)
        {
            var ticket = baseDTO as Ticket;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_TICKET_PR";

            sqlOperation.AddIntParameter("P_ID", ticket.Id);
            sqlOperation.AddDouble("P_PRICE", ticket.Price);
            sqlOperation.AddTimeParameter("P_SCHEDULE", ticket.Schedule);
            sqlOperation.AddDateTimeParameter("P_DATE", ticket.Date);
            sqlOperation.AddStringParameter("P_TYPE", ticket.Type);
            sqlOperation.AddIntParameter("P_MOVIE_ID", ticket.Movie.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

    }
}
