using DataAccess.DAO;
using Entities_DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory()
        {
            sqlDao = SqlDao.getInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SYNOPSIS", movie.Synopsis);
            sqlOperation.AddStringParameter("P_GENDER", movie.Gender);
            sqlOperation.AddStringParameter("P_CLASIFICACION", movie.Clasificacion);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();

            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_MOVIE_PR";

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                foreach (var result in lstResults)
                {
                    var movie = BuildMovie(result);

                    lstMovies.Add((T)Convert.ChangeType(movie, typeof(T)));
                }
            }

            return lstMovies;
        }

        private Movie BuildMovie(Dictionary<string, object> row)
        {
            return new Movie()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                Title = (string)row["Title"],
                Synopsis = (string)row["Synopsis"],
                Gender = (string)row["Gender"],
                Clasificacion = (string)row["Clasificacion"],
                Image = (string)row["Image"],
                Status = (string)row["Status"]
            };
        }

        public override void Delete(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_MOVIE_PR";

            sqlOperation.AddIntParameter("P_ID", movie.Id);

            sqlDao.ExecuteProcedure(sqlOperation);
        }
        public override T RetrieveById<T>(int id) => throw new NotImplementedException();
        public override void Update(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;

            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_MOVIE_PR";

            sqlOperation.AddIntParameter("P_ID", movie.Id);
            sqlOperation.AddStringParameter("P_TITLE", movie.Title);
            sqlOperation.AddStringParameter("P_SYNOPSIS", movie.Synopsis);
            sqlOperation.AddStringParameter("P_GENDER", movie.Gender);
            sqlOperation.AddStringParameter("P_CLASIFICACION", movie.Clasificacion);
            sqlOperation.AddStringParameter("P_IMAGE", movie.Image);
            sqlOperation.AddStringParameter("P_STATUS", movie.Status);

            sqlDao.ExecuteProcedure(sqlOperation);
        }
    }
}