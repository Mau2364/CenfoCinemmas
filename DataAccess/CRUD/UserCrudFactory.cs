using DataAccess.DAO;
using Entities_DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {
        public UserCrudFactory() { 
            
            sqlDao = SqlDao.getInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            // convierte el base DTO en un objeto usuario
            var user = baseDTO as User;
            //definir el SP, por medio del sql operation
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParameter("P_USER_CODE", user.UserCode);
            sqlOperation.AddStringParameter("P_NAME", user.Name);
            sqlOperation.AddStringParameter("P_EMAIL", user.Email);
            sqlOperation.AddStringParameter("P_PASSWORD", user.Password);
            sqlOperation.AddDateTimeParameter("P_DATE_BIRTH", user.DateBirth);
            sqlOperation.AddStringParameter("P_STATUS", user.Status);
            sqlOperation.AddIntParameter("P_PHONE_NUMBER",user.PhoneNumber);

           //ejecutamos el sp 
           sqlDao.ExecuteProcedure(sqlOperation);

        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ALL_USER_PR";

            var lstResults = sqlDao.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                foreach (var result in lstResults)
                {
                    var user = BuildUser(result);

                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }
            return lstUsers;
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
        // metodo que construye el DTO del usuario a partir de la data que viene en la consulta de la BD

        private User BuildUser (Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id = (int)row["Id"],
                Created = (DateTime)row["Created"],
                UserCode = (string)row["UserCode"],
                Name = (string)row["Name"],
                Email = (string)row["Email"],
                Password = (string)row["Password"],
                Status = (string)row["Status"],
                DateBirth = (DateTime)row["DateBirth"],
                PhoneNumber = (int) row["PhoneNumber"]
            };
            return user;
        }
    }
}

