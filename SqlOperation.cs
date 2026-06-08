using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DataAccess.DAO
{
    public class SqlOperation
    {
        // clase que define el procedimiento a ejecutar y sus parametros
        public string ProcedureName { get; set; }

        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        //solo vamos a trabajar con estos 4 tipos
        public void AddStringParameter(string parameterName, string value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }

        public void AddIntParameter(string parameterName, int value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }
        public void AddDouble(string parameterName, double value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }
        public void AddDateTimeParameter(string parameterName, DateTime value)
        {
            Parameters.Add(new SqlParameter(parameterName, value));
        }
    }

}