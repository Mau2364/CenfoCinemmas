using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DataAccess.DAO
{
    /*
     Clase que se encarga de la comunicacion con la bd,
     solo ejecuta store procedures.

     Implementa el patron singleton, para asegurar que solo sea un objeto el que se conecta a la bd
     y centraliza esta gestion
    */
    public class SqlDao
    {
        // Paso 1: Crear una instancia privada de esta misma clase
        private static SqlDao instance;

        public CommandType CommandType { get; private set; }

        private string connectionString;

        // Paso 2: Redefinir el constructor default de la clase
        private SqlDao()
        {
            connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=cenfocinemas;Integrated Security=True;Trust Server Certificate=True";

            Console.WriteLine(connectionString);
        }

        // Paso 3: definir un metodo estatico que expone la instancia
        public static SqlDao getInstance()
        {
            if (instance == null)
            {
                instance = new SqlDao();
            }

            return instance;
        }

        // metodo que ejecuta de acuerdo a la especificacion del parametro
        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(sqlOperation.ProcedureName, conn))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // set de los parameters que utiliza el SP
                    foreach (var param in sqlOperation.Parameters)
                    {
                        command.Parameters.Add(param);
                    }

                    // ejecuta store procedure (SP)
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        // lo puse para probar la conexion
        public void TestConnection()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine("Conexión exitosa.");
            }
        }

        // metodo para ejecutar el sp en la bd y obtener un resultado 
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var listResults = new List<Dictionary<string, object>>();

            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // set de los parameters que utiliza el SP
                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                // ejecuta store procedure (SP)
                conn.Open();

                // ejecucion sp con retorno de datos
                Console.WriteLine("SP: " + sqlOperation.ProcedureName);
                var reader = command.ExecuteReader();

                // lectura de data set
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();

                        for (var index = 0; index < reader.FieldCount; index++)
                        {
                            var key = reader.GetName(index);
                            var value = reader.GetValue(index);

                            row[key] = value;
                        }

                        listResults.Add(row);
                    }
                }
            }

            return listResults;
        }
    }
}