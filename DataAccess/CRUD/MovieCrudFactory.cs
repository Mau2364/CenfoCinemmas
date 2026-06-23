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

        public override void Delete(BaseDTO baseDTO) => throw new NotImplementedException();
        public override List<T> RetrieveAll<T>() => throw new NotImplementedException();
        public override T RetrieveById<T>(int id) => throw new NotImplementedException();
        public override void Update(BaseDTO baseDTO) => throw new NotImplementedException();
    }
}