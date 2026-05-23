using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.DAO
{
    /*
     Clase que se encarga de la comunicacion con la bd,
    solo ejecuta store procedures
    Implementa el patron singleton, para asegurar que solo sea un objeto el que se conecta a la bd
    y centraliza esta gestion
     */
    public class SqlDao
    {
        //Paso 1: Crear una instancia privada de esta misma clase
        private static SqlDao instance;

        public CommandType CommandType { get; private set; }

        private string connectionString;

        //paso 2: Redefinir el constructor default de la clase
        private SqlDao () { 
            connectionString = string .Empty;
        }

        // paso 3: definir un metodo estatico que expone la instancia
        public static SqlDao getInstance () {
            if (instance == null)
            {
                instance = new SqlDao ();
            }
            return instance;
    }
        // metodo que ejecuta de acuerdo a la especificacion del parametro
        public void ExecuteProcedure (SqlOperation sqlOperation)
        {
            using (var conn= new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand (sqlOperation.ProcedureName, conn))
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //set de los parameters que utiliza el SP
                    foreach (var param in sqlOperation.Parameters) {
                        command.Parameters.Add(param);
                }
                    // ejecuta store procedure (SP)
                    conn.Open();
                    command.ExecuteQuery();
            }
        }
}

